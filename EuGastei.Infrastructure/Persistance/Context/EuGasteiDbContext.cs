using EuGastei.Domain.Entities;
using EuGastei.Infrastructure.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EuGastei.Infrastructure.Persistance.Context
{
    public class EuGasteiDbContext : DbContext
    {
        public EuGasteiDbContext(DbContextOptions<EuGasteiDbContext> options) : base(options) { }

        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<PerfilPermissao> PerfisPermissoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected EuGasteiDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyAllConfigurations(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ApplyAllConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PerfilConfiguration());
            modelBuilder.ApplyConfiguration(new PermissaoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PerfilPermissaoConfiguration());
        }
    }
}
