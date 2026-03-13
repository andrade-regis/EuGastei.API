using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface IPermissaoRepository
    {
        Task<Permissao> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(Permissao permissao, CancellationToken cancellation = default);
        Task AtualizarAsync(Permissao permissao, CancellationToken cancellation = default);
        Task RemoverAsync(Permissao permissao, CancellationToken cancellation = default);
        Task<ICollection<Permissao>> ListarAsync(Expression<Func<Permissao, bool>>? condicao = null,
                                                     CancellationToken cancellation = default);
        Task SaveChangesAsync();
    }
}
