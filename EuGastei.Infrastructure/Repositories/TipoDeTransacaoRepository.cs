using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class TipoDeTransacaoRepository : ITipoDeTransacaoRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<TipoDeTransacao> DbSet;

        public TipoDeTransacaoRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<TipoDeTransacao>();
        }

        public async Task AdicionarAsync(TipoDeTransacao tipoDeTransacao, CancellationToken cancellation = default)
        {
            DbSet.Add(tipoDeTransacao);
        }
        public async Task AtualizarAsync(TipoDeTransacao tipoDeTransacao, CancellationToken cancellation = default)
        {
            DbSet.Update(tipoDeTransacao);
        }
        public async Task<ICollection<TipoDeTransacao>> ListarAsync(Expression<Func<TipoDeTransacao, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            var query = DbSet.AsNoTracking();
            if (condicao != null) query = query.Where(condicao);
            return await query.ToListAsync();
        }
        public async Task<TipoDeTransacao> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(TipoDeTransacao tipoDeTransacao, CancellationToken cancellation = default)
        {
            DbSet.Remove(tipoDeTransacao);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
