using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<Categoria> DbSet;

        public CategoriaRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<Categoria>();
        }

        public async Task AdicionarAsync(Categoria categoria, CancellationToken cancellation = default)
        {
            DbSet.Add(categoria);
        }
        public async Task AtualizarAsync(Categoria categoria, CancellationToken cancellation = default)
        {
            DbSet.Update(categoria);
        }
        public async Task<ICollection<Categoria>> ListarAsync(Expression<Func<Categoria, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            var query = DbSet.AsNoTracking();
            if (condicao != null) query = query.Where(condicao);
            return await query.ToListAsync();
        }
        public async Task<Categoria> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(Categoria categoria, CancellationToken cancellation = default)
        {
            DbSet.Remove(categoria);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
