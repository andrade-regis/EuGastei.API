using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Application.Interfaces
{
    public interface IFormaDePagamentoService
    {
        Task<FormaDePagamento> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(FormaDePagamento formaDePagamento, CancellationToken cancellation = default);
        Task AtualizarAsync(FormaDePagamento formaDePagamento, CancellationToken cancellation = default);
        Task RemoverAsync(Guid id, CancellationToken cancellation = default);
        Task<ICollection<FormaDePagamento>> ListarAsync(Expression<Func<FormaDePagamento, bool>>? condicao = null, CancellationToken cancellation = default);
    }
}
