using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface IPerfilPermissaoRepository
    {
        Task<PerfilPermissao> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(PerfilPermissao perfilPermissao, CancellationToken cancellation = default);
        Task AtualizarAsync(PerfilPermissao perfilPermissao, CancellationToken cancellation = default);
        Task RemoverAsync(PerfilPermissao perfilPermissao, CancellationToken cancellation = default);
        Task<ICollection<PerfilPermissao>> ListarAsync(Expression<Func<PerfilPermissao, bool>>? condicao = null, 
                                                     CancellationToken cancellation = default);
        public Task SaveChangesAsync();
    }
}
