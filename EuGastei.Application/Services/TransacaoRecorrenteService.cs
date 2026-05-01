using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Application.Interfaces;
using System.Linq.Expressions;

namespace EuGastei.Application.Services
{
    public class TransacaoRecorrenteService : ITransacaoRecorrenteService
    {
        private readonly ITransacaoRecorrenteRepository _repository;

        public TransacaoRecorrenteService(ITransacaoRecorrenteRepository repository)
        {
            _repository = repository;
        }

        public async Task<TransacaoRecorrente> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await _repository.ObterPorIdAsync(id, cancellation);
        }

        public async Task AdicionarAsync(TransacaoRecorrente transacaoRecorrente, CancellationToken cancellation = default)
        {
            await _repository.AdicionarAsync(transacaoRecorrente, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task AtualizarAsync(TransacaoRecorrente transacaoRecorrente, CancellationToken cancellation = default)
        {
            await _repository.AtualizarAsync(transacaoRecorrente, cancellation);
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

        public async Task<ICollection<TransacaoRecorrente>> ListarAsync(Expression<Func<TransacaoRecorrente, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            return await _repository.ListarAsync(condicao, cancellation);
        }
    }
}
