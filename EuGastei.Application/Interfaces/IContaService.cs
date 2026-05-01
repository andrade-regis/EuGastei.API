using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Application.Interfaces
{
    public interface IContaService
    {
        Task<Conta> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(Conta conta, CancellationToken cancellation = default);
        Task AtualizarAsync(Conta conta, CancellationToken cancellation = default);
        Task RemoverAsync(Guid id, CancellationToken cancellation = default);
        Task<ICollection<Conta>> ListarAsync(Expression<Func<Conta, bool>>? condicao = null, CancellationToken cancellation = default);
    }
}
