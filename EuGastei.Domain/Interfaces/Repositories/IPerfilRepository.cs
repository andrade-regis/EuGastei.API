using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface IPerfilRepository
    {
        Task<Perfil> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(Perfil perfil, CancellationToken cancellation = default);
        Task AtualizarAsync(Perfil perfil, CancellationToken cancellation = default);
        Task RemoverAsync(Perfil perfil, CancellationToken cancellation = default);
        Task<ICollection<Perfil>> ListarAsync(Expression<Func<Perfil, bool>>? condicao = null,
                                                     CancellationToken cancellation = default);
        Task SaveChangesAsync();
    }
}
