using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface ITenantRepository
    {
        Task<Tenant> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        void Adicionar(Tenant tenant, CancellationToken cancellation = default);
        void Atualizar(Tenant tenant, CancellationToken cancellation = default);
        void Remover(Tenant tenant, CancellationToken cancellation = default);
        Task<ICollection<Tenant>> ListarAsync(Expression<Func<Tenant, bool>>? condicao = null,
                                                     CancellationToken cancellation = default);
        Task SaveChangesAsync();
    }
}
