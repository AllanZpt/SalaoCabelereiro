using Microsoft.EntityFrameworkCore;
using SalaoCabelo.Enum;
using SalaoCabelo.Models;

namespace SalaoCabelo.Data
{
    public class SalaoContext : DbContext
    {
        public SalaoContext(DbContextOptions<SalaoContext> options) : base(options) { }

        public DbSet<Usuarios> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Perfil)
                .HasDefaultValue(PerfilEnum.Padrao); // Define o valor padrão para Perfil
        }
    }
}
