using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using NutriMais.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NutriMais.Repositories.User;
using NutriMais.Repositories.Appointment;
using NutriMais.Repositories.Communication;
using NutriMais.Services.Appointment;
using Google.Apis.Calendar.v3;
using Google.Apis.Auth.OAuth2;
using System.IO;
using Google.Apis.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NutriMais.Services.GoogleIntegration.CalendarServices;
using Google.Apis.Sheets.v4;
using Quartz.Spi;
using Quartz;
using NutriMais.Tasks;
using Quartz.Impl;
using NutriMais.Tasks.Appointment;
using NutriMais.Services.GoogleIntegration.EmailServices;
using NutriMais.Repositories.Planos;
using NutriMais.Repositories.Receitas;

namespace NutriMais
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NutriMaisContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => 
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<NutriMaisContext>();


            services.AddControllersWithViews();
            services.AddRazorPages();

            SetGoogleIntegration(services);
            BindProvider(services);
            BindSingletons(services);
            AddTasks(services);
        }

        public void AddTasks(IServiceCollection services)
        {
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<SendCheckInEmailsTask>();
            services.AddSingleton(new JobSchedule(jobType: typeof(SendCheckInEmailsTask), cronExpression: "00 09 * * * ?"));
            services.AddHostedService<QuartzHostedService>();
        }

        public void BindProvider(IServiceCollection services)
        {
            services.AddScoped<AppointmentServiceInterface, AppointmentService>();
            services.AddScoped<AppointmentRepositoryInterface, AppointmentRepository>();
            services.AddScoped<UserRepositoryInterface, UserRepository>();
            services.AddScoped<CommunicationRepositoryInterface, CommunicationRepository>();
            services.AddScoped<IPlanoRepositoryInterface, PlanoRepository>();
            services.AddScoped<IReceitaRepository, ReceitaRepository>();
        }

        public void BindSingletons(IServiceCollection services)
        {
            services.AddSingleton<CalendarServiceInterface, NutriMaisCalendarService>();
            services.AddSingleton<EmailServiceInterface, EmailService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        public void SetGoogleIntegration (IServiceCollection services)
        {
            var name = "NutriMais";
            var credential = GetGoogleCredential();
            var sheetService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = credential, ApplicationName = name,});
            services.AddSingleton(sheetService);
        }

        public ServiceAccountCredential GetGoogleCredential()
        {

            var credentials = (JObject) JsonConvert.DeserializeObject(File.ReadAllText("credentials.json")); 
            var key = (string)credentials.GetValue("private_key");
            var serviceAccount = "nutrimais@master-car-314123.iam.gserviceaccount.com";
            return new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(serviceAccount)
                {
                    Scopes = new[] { CalendarService.Scope.Calendar, SheetsService.Scope.Spreadsheets }
                }.FromPrivateKey(key));
        }
    }
}
