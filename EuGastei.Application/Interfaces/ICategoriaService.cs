using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<Categoria> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(Categoria categoria, CancellationToken cancellation = default);
        Task AtualizarAsync(Categoria categoria, CancellationToken cancellation = default);
        Task RemoverAsync(Guid id, CancellationToken cancellation = default);
        Task<ICollection<Categoria>> ListarAsync(Expression<Func<Categoria, bool>>? condicao = null, CancellationToken cancellation = default);
    }
}
