using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutriMais.Models;
using System.Threading.Tasks;

namespace NutriMais.Data
{
    public class NutriMaisContext : IdentityDbContext
    {
        public NutriMaisContext (DbContextOptions<NutriMaisContext> options)
            : base(options)
        {
        }
        public DbSet<AppointmentModel> AppointmentModel { get; set; }
        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<CommunicationModel> CommunicationModel { get; set; }
        public DbSet<PlanosModel> PlanosModel { get; set; }
        public DbSet<PlanoSemanalModel> PlanoSemanalModel { get; set; }
	public DbSet<ReceitasModel> ReceitasModel { get; set; }
	public DbSet<FichaModel> FichaModel { get; set; }
    }
}
