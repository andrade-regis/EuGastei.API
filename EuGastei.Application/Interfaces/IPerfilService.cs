using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Application.Interfaces
{
    public interface IPerfilService
    {
        Task<Perfil> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(Perfil perfil, CancellationToken cancellation = default);
        Task AtualizarAsync(Perfil perfil, CancellationToken cancellation = default);
        Task RemoverAsync(Guid id, CancellationToken cancellation = default);
        Task<ICollection<Perfil>> ListarAsync(Expression<Func<Perfil, bool>>? condicao = null, CancellationToken cancellation = default);
    }
}
