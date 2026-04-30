using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<Tenant> DbSet;

        public TenantRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<Tenant>();
        }

        public async Task AdicionarAsync(Tenant tenant, CancellationToken cancellation = default)
        {
            DbSet.Add(tenant);
        }
        public async Task AtualizarAsync(Tenant tenant, CancellationToken cancellation = default)
        {
            DbSet.Update(tenant);
        }
        public async Task<ICollection<Tenant>> ListarAsync(Expression<Func<Tenant, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            var query = DbSet.AsNoTracking();
            if (condicao != null) query = query.Where(condicao);
            return await query.ToListAsync();
        }
        public async Task<Tenant> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(Tenant tenant, CancellationToken cancellation = default)
        {
            DbSet.Remove(tenant);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
