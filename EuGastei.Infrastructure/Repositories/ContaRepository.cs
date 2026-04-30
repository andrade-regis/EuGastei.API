using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class ContaRepository : IContaRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<Conta> DbSet;

        public ContaRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<Conta>();
        }

        public async Task AdicionarAsync(Conta conta, CancellationToken cancellation = default)
        {
            DbSet.Add(conta);
        }
        public async Task AtualizarAsync(Conta conta, CancellationToken cancellation = default)
        {
            DbSet.Update(conta);
        }
        public async Task<ICollection<Conta>> ListarAsync(Expression<Func<Conta, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            var query = DbSet.AsNoTracking();
            if (condicao != null) query = query.Where(condicao);
            return await query.ToListAsync();
        }
        public async Task<Conta> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(Conta conta, CancellationToken cancellation = default)
        {
            DbSet.Remove(conta);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
