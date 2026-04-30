using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<Transacao> DbSet;

        public TransacaoRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<Transacao>();
        }

        public async Task AdicionarAsync(Transacao transacao, CancellationToken cancellation = default)
        {
            DbSet.Add(transacao);
        }
        public async Task AtualizarAsync(Transacao transacao, CancellationToken cancellation = default)
        {
            DbSet.Update(transacao);
        }
        public async Task<ICollection<Transacao>> ListarAsync(Expression<Func<Transacao, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            var query = DbSet.AsNoTracking();
            if (condicao != null) query = query.Where(condicao);
            return await query.ToListAsync();
        }
        public async Task<Transacao> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(Transacao transacao, CancellationToken cancellation = default)
        {
            DbSet.Remove(transacao);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
