using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class TransacaoRecorrenteRepository : ITransacaoRecorrenteRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<TransacaoRecorrente> DbSet;

        public TransacaoRecorrenteRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<TransacaoRecorrente>();
        }

        public async Task AdicionarAsync(TransacaoRecorrente transacaoRecorrente, CancellationToken cancellation = default)
        {
            DbSet.Add(transacaoRecorrente);
        }
        public async Task AtualizarAsync(TransacaoRecorrente transacaoRecorrente, CancellationToken cancellation = default)
        {
            DbSet.Update(transacaoRecorrente);
        }
        public async Task<ICollection<TransacaoRecorrente>> ListarAsync(Expression<Func<TransacaoRecorrente, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            var query = DbSet.AsNoTracking();
            if (condicao != null) query = query.Where(condicao);
            return await query.ToListAsync();
        }
        public async Task<TransacaoRecorrente> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(TransacaoRecorrente transacaoRecorrente, CancellationToken cancellation = default)
        {
            DbSet.Remove(transacaoRecorrente);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
