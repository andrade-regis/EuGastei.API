using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface IFormaDePagamentoRepository
    {
        Task<FormaDePagamento> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(FormaDePagamento formaDePagamento, CancellationToken cancellation = default);
        Task AtualizarAsync(FormaDePagamento formaDePagamento, CancellationToken cancellation = default);
        Task RemoverAsync(FormaDePagamento formaDePagamento, CancellationToken cancellation = default);
        Task<ICollection<FormaDePagamento>> ListarAsync(Expression<Func<FormaDePagamento, bool>>? condicao = null,
                                                     CancellationToken cancellation = default);
        Task SaveChangesAsync();
    }
}
