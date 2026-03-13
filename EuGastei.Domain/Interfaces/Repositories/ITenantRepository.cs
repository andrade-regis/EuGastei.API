using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface ITenantRepository
    {
        Task<Tenant> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(Tenant tenant, CancellationToken cancellation = default);
        Task AtualizarAsync(Tenant tenant, CancellationToken cancellation = default);
        Task RemoverAsync(Tenant tenant, CancellationToken cancellation = default);
        Task<ICollection<Tenant>> ListarAsync(Expression<Func<Tenant, bool>>? condicao = null,
                                                     CancellationToken cancellation = default);
        Task SaveChangesAsync();
    }
}
