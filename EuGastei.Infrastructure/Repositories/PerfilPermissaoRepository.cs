using System.Linq.Expressions;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class PerfilPermissaoRepository : IPerfilPermissaoRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<PerfilPermissao> DbSet;


        public PerfilPermissaoRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<PerfilPermissao>();
        }


        public async Task AdicionarAsync(PerfilPermissao perfilPermissao, CancellationToken cancellation = default)
        {
            DbSet.Add(perfilPermissao);
        }
        public async Task AtualizarAsync(PerfilPermissao perfilPermissao, CancellationToken cancellation = default)
        {
            DbSet.Update(perfilPermissao);
        }
        public async Task<ICollection<PerfilPermissao>> ListarAsync(Expression<Func<PerfilPermissao, bool>>? condicao = null, 
                                                                    CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .Where(condicao)
                              .ToListAsync();
        }
        public async Task<PerfilPermissao> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(PerfilPermissao perfilPermissao, CancellationToken cancellation = default)
        {
            DbSet.Remove(perfilPermissao);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
