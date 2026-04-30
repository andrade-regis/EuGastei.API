using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class AnoRepository : IAnoRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<Ano> DbSet;

        public AnoRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<Ano>();
        }

        public async Task AdicionarAsync(Ano ano, CancellationToken cancellation = default)
        {
            DbSet.Add(ano);
        }
        public async Task AtualizarAsync(Ano ano, CancellationToken cancellation = default)
        {
            DbSet.Update(ano);
        }
        public async Task<ICollection<Ano>> ListarAsync(Expression<Func<Ano, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            var query = DbSet.AsNoTracking();
            if (condicao != null) query = query.Where(condicao);
            return await query.ToListAsync();
        }
        public async Task<Ano> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(Ano ano, CancellationToken cancellation = default)
        {
            DbSet.Remove(ano);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
