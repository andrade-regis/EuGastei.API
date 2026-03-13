using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class PermissaoRepository : IPermissaoRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<Permissao> DbSet;

        public PermissaoRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<Permissao>();
        }

        public async Task AdicionarAsync(Permissao permissao, CancellationToken cancellation = default)
        {
            DbSet.Add(permissao);
        }
        public async Task AtualizarAsync(Permissao permissao, CancellationToken cancellation = default)
        {
            DbSet.Update(permissao);
        }
        public async Task<ICollection<Permissao>> ListarAsync(Expression<Func<Permissao, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .Where(condicao)
                              .ToListAsync();
        }
        public async Task<Permissao> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(Permissao permissao, CancellationToken cancellation = default)
        {
            DbSet.Remove(permissao);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
