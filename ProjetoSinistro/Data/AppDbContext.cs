using Microsoft.EntityFrameworkCore;
using ProjetoSinistro.Models;

namespace ProjetoSinistro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>().ToTable("PACIENTE");
        }
    }
}
