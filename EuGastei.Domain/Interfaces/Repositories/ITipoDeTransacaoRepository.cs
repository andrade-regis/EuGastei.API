using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface ITipoDeTransacaoRepository
    {
        Task<TipoDeTransacao> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(TipoDeTransacao tipoDeTransacao, CancellationToken cancellation = default);
        Task AtualizarAsync(TipoDeTransacao tipoDeTransacao, CancellationToken cancellation = default);
        Task RemoverAsync(TipoDeTransacao tipoDeTransacao, CancellationToken cancellation = default);
        Task<ICollection<TipoDeTransacao>> ListarAsync(Expression<Func<TipoDeTransacao, bool>>? condicao = null,
                                                     CancellationToken cancellation = default);
        Task SaveChangesAsync();
    }
}
