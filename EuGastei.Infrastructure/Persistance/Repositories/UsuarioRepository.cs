using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<Usuario> DbSet;

        public UsuarioRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<Usuario>();
        }

        public void Adicionar(Usuario usuario, CancellationToken cancellation = default)
        {
            DbSet.Add(usuario);
        }

        public void Atualizar(Usuario usuario, CancellationToken cancellation = default)
        {
            DbSet.Update(usuario);
        }

        public async Task<ICollection<Usuario>> ListarAsync(Expression<Func<Usuario, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                .Where(condicao)
                .ToListAsync();
        }

        public async Task<Usuario> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remover(Usuario usuario, CancellationToken cancellation = default)
        {
            DbSet.Remove(usuario);
        }

        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
