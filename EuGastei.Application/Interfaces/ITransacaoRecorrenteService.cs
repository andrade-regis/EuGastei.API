using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Application.Interfaces
{
    public interface ITransacaoRecorrenteService
    {
        Task<TransacaoRecorrente> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(TransacaoRecorrente transacaoRecorrente, CancellationToken cancellation = default);
        Task AtualizarAsync(TransacaoRecorrente transacaoRecorrente, CancellationToken cancellation = default);
        Task RemoverAsync(Guid id, CancellationToken cancellation = default);
        Task<ICollection<TransacaoRecorrente>> ListarAsync(Expression<Func<TransacaoRecorrente, bool>>? condicao = null, CancellationToken cancellation = default);
    }
}
