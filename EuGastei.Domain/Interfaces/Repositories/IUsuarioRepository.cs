using EuGastei.Domain.Entities;
using System.Linq.Expressions;
using EuGastei.Domain.QueryObject;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        void Adicionar(Usuario usuario, CancellationToken cancellation = default);
        void Atualizar(Usuario usuario, CancellationToken cancellation = default);
        void Remover(Usuario usuario, CancellationToken cancellation = default);
        public Task<IEnumerable<Usuario>> ListarPorFiltro(UsuarioFiltro filtro);
        public Task SaveChangesAsync();
    }
}
