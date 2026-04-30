using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface ITransacaoRepository
    {
        Task<Transacao> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(Transacao transacao, CancellationToken cancellation = default);
        Task AtualizarAsync(Transacao transacao, CancellationToken cancellation = default);
        Task RemoverAsync(Transacao transacao, CancellationToken cancellation = default);
        Task<ICollection<Transacao>> ListarAsync(Expression<Func<Transacao, bool>>? condicao = null,
                                                     CancellationToken cancellation = default);
        Task SaveChangesAsync();
    }
}
