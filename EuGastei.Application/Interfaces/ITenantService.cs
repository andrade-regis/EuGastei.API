using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Application.Interfaces
{
    public interface ITenantService
    {
        Task<Tenant> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(Tenant tenant, CancellationToken cancellation = default);
        Task AtualizarAsync(Tenant tenant, CancellationToken cancellation = default);
        Task RemoverAsync(Guid id, CancellationToken cancellation = default);
        Task<ICollection<Tenant>> ListarAsync(Expression<Func<Tenant, bool>>? condicao = null, CancellationToken cancellation = default);
    }
}
