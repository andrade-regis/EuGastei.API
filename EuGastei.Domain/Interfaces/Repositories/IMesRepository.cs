using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface IMesRepository
    {
        Task<Mes> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(Mes mes, CancellationToken cancellation = default);
        Task AtualizarAsync(Mes mes, CancellationToken cancellation = default);
        Task RemoverAsync(Mes mes, CancellationToken cancellation = default);
        Task<ICollection<Mes>> ListarAsync(Expression<Func<Mes, bool>>? condicao = null,
                                                     CancellationToken cancellation = default);
        Task SaveChangesAsync();
    }
}
