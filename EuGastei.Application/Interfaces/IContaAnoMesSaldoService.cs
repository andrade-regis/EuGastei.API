using EuGastei.Domain.Entities;
using System.Linq.Expressions;

namespace EuGastei.Application.Interfaces
{
    public interface IContaAnoMesSaldoService
    {
        Task<ContaAnoMesSaldo> ObterPorIdAsync(Guid id, CancellationToken cancellation = default);
        Task AdicionarAsync(ContaAnoMesSaldo contaAnoMesSaldo, CancellationToken cancellation = default);
        Task AtualizarAsync(ContaAnoMesSaldo contaAnoMesSaldo, CancellationToken cancellation = default);
        Task RemoverAsync(Guid id, CancellationToken cancellation = default);
        Task<ICollection<ContaAnoMesSaldo>> ListarAsync(Expression<Func<ContaAnoMesSaldo, bool>>? condicao = null, CancellationToken cancellation = default);
    }
}
