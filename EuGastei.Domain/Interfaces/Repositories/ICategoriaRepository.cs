using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(Categoria categoria, CancellationToken cancellation = default);
        Task AtualizarAsync(Categoria categoria, CancellationToken cancellation = default);
        Task RemoverAsync(Categoria categoria, CancellationToken cancellation = default);
        Task<ICollection<Categoria>> ListarAsync(Expression<Func<Categoria, bool>>? condicao = null,
                                                     CancellationToken cancellation = default);
        Task SaveChangesAsync();
    }
}
