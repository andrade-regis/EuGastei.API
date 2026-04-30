using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<Perfil> DbSet;

        public PerfilRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<Perfil>();
        }

        public async Task AdicionarAsync(Perfil perfil, CancellationToken cancellation = default)
        {
            DbSet.Add(perfil);
        }
        public async Task AtualizarAsync(Perfil perfil, CancellationToken cancellation = default)
        {
            DbSet.Update(perfil);
        }
        public async Task<ICollection<Perfil>> ListarAsync(Expression<Func<Perfil, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .Where(condicao)
                              .ToListAsync();
        }
        public async Task<Perfil> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(Perfil perfil, CancellationToken cancellation = default)
        {
            DbSet.Remove(perfil);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
