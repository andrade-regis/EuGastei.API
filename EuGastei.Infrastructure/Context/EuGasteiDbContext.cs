using EuGastei.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuGastei.Infrastructure.Context
{
    public class EuGasteiDbContext : DbContext
    {
        public EuGasteiDbContext(DbContextOptions<EuGasteiDbContext> options) : base(options) { }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<PerfilPermissao> PerfisPermissoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ano> Anos { get; set; }
        public DbSet<Mes> Meses { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<TipoDeTransacao> TiposDeTransacao { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<FormaDePagamento> FormasDePagamento { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<TransacaoRecorrente> TransacoesRecorrentes { get; set; }
        public DbSet<ContaAnoMesSaldo> ContasAnosMesesSaldos { get; set; }

        protected EuGasteiDbContext()
        {
        }
    }
}
