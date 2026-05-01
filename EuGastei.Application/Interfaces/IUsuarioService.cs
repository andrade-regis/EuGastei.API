using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(Usuario usuario, CancellationToken cancellation = default);
        Task AtualizarAsync(Usuario usuario, CancellationToken cancellation = default);
        Task RemoverAsync(Guid id, CancellationToken cancellation = default);
        Task<ICollection<Usuario>> ListarAsync(Expression<Func<Usuario, bool>>? condicao = null, CancellationToken cancellation = default);
    }
}
