using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class MesRepository : IMesRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<Mes> DbSet;

        public MesRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<Mes>();
        }

        public async Task AdicionarAsync(Mes mes, CancellationToken cancellation = default)
        {
            DbSet.Add(mes);
        }
        public async Task AtualizarAsync(Mes mes, CancellationToken cancellation = default)
        {
            DbSet.Update(mes);
        }
        public async Task<ICollection<Mes>> ListarAsync(Expression<Func<Mes, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            var query = DbSet.AsNoTracking();
            if (condicao != null) query = query.Where(condicao);
            return await query.ToListAsync();
        }
        public async Task<Mes> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(Mes mes, CancellationToken cancellation = default)
        {
            DbSet.Remove(mes);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
