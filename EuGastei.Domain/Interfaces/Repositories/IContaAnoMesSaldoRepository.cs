using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Domain.Interfaces.Repositories
{
    public interface IContaAnoMesSaldoRepository
    {
        Task<ContaAnoMesSaldo> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(ContaAnoMesSaldo contaAnoMesSaldo, CancellationToken cancellation = default);
        Task AtualizarAsync(ContaAnoMesSaldo contaAnoMesSaldo, CancellationToken cancellation = default);
        Task RemoverAsync(ContaAnoMesSaldo contaAnoMesSaldo, CancellationToken cancellation = default);
        Task<ICollection<ContaAnoMesSaldo>> ListarAsync(Expression<Func<ContaAnoMesSaldo, bool>>? condicao = null,
                                                     CancellationToken cancellation = default);
        Task SaveChangesAsync();
    }
}
