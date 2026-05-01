using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Application.Interfaces
{
    public interface ITipoDeTransacaoService
    {
        Task<TipoDeTransacao> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(TipoDeTransacao tipoDeTransacao, CancellationToken cancellation = default);
        Task AtualizarAsync(TipoDeTransacao tipoDeTransacao, CancellationToken cancellation = default);
        Task RemoverAsync(Guid id, CancellationToken cancellation = default);
        Task<ICollection<TipoDeTransacao>> ListarAsync(Expression<Func<TipoDeTransacao, bool>>? condicao = null, CancellationToken cancellation = default);
    }
}
