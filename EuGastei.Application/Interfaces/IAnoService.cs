using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Application.Interfaces
{
    public interface IAnoService
    {
        Task<Ano> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(Ano ano, CancellationToken cancellation = default);
        Task AtualizarAsync(Ano ano, CancellationToken cancellation = default);
        Task RemoverAsync(Guid id, CancellationToken cancellation = default);
        Task<ICollection<Ano>> ListarAsync(Expression<Func<Ano, bool>>? condicao = null, CancellationToken cancellation = default);
    }
}
