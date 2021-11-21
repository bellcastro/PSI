using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NutriMais.Repositories.Appointment;
using NutriMais.Services.Appointment;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Tasks.Appointment
{
    public class SendCheckInEmailsTask : IJob
    {
        private readonly ILogger<SendCheckInEmailsTask> _logger;
        private readonly IServiceProvider _provider;

        public SendCheckInEmailsTask(ILogger<SendCheckInEmailsTask> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        public Task Execute(IJobExecutionContext context)
        {
            using (var scope = _provider.CreateScope())
            {
                // Resolve the Scoped service
                var repository = scope.ServiceProvider.GetService<AppointmentRepositoryInterface>();
                var service = scope.ServiceProvider.GetService<AppointmentServiceInterface>();
                Handle(service, repository).Wait();
            }
            return Task.CompletedTask;
        }

        public async Task Handle(AppointmentServiceInterface service, AppointmentRepositoryInterface repositoryInterface)
        {
            var models = await repositoryInterface.GetConfirmedAppointmentsCloseToStart();
            foreach (var model in models)
            {
                _logger.LogInformation("Enviando email da consulta {}", model.Id);
                service.DispatchCheckInEmail(model);
            }
            return;
        }
    }
}
