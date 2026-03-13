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

        public async Task AdicionarAsync(Usuario usuario, CancellationToken cancellation = default)
        {
            DbSet.Add(usuario);
        }

        public async Task AtualizarAsync(Usuario usuario, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Usuario>> ListarAsync(Expression<Func<Usuario, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public async Task RemoverAsync(Usuario usuario, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
