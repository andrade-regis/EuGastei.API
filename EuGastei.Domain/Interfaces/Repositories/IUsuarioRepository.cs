using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        void Adicionar(Usuario usuario, CancellationToken cancellation = default);
        void Atualizar(Usuario usuario, CancellationToken cancellation = default);
        void Remover(Usuario usuario, CancellationToken cancellation = default);
        public IQueryable<Usuario> ListarByQueryable(CancellationToken cancellation = default);
        public Task SaveChangesAsync();
    }
}
