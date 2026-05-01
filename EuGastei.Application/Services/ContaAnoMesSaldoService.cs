using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Application.Interfaces;
using System.Linq.Expressions;

namespace EuGastei.Application.Services
{
    public class ContaAnoMesSaldoService : IContaAnoMesSaldoService
    {
        private readonly IContaAnoMesSaldoRepository _repository;

        public ContaAnoMesSaldoService(IContaAnoMesSaldoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContaAnoMesSaldo> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await _repository.ObterPorIdAsync(id, cancellation);
        }

        public async Task AdicionarAsync(ContaAnoMesSaldo contaAnoMesSaldo, CancellationToken cancellation = default)
        {
            await _repository.AdicionarAsync(contaAnoMesSaldo, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task AtualizarAsync(ContaAnoMesSaldo contaAnoMesSaldo, CancellationToken cancellation = default)
        {
            await _repository.AtualizarAsync(contaAnoMesSaldo, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id, CancellationToken cancellation = default)
        {
            var entity = await _repository.ObterPorIdAsync(id, cancellation);
            if (entity != null)
            {
                await _repository.RemoverAsync(entity, cancellation);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<ICollection<ContaAnoMesSaldo>> ListarAsync(Expression<Func<ContaAnoMesSaldo, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            return await _repository.ListarAsync(condicao, cancellation);
        }
    }
}
