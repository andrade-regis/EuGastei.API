using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Application.Interfaces;
using System.Linq.Expressions;

namespace EuGastei.Application.Services
{
    public class AnoService : IAnoService
    {
        private readonly IAnoRepository _repository;

        public AnoService(IAnoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Ano> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await _repository.ObterPorIdAsync(id, cancellation);
        }

        public async Task AdicionarAsync(Ano ano, CancellationToken cancellation = default)
        {
            await _repository.AdicionarAsync(ano, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Ano ano, CancellationToken cancellation = default)
        {
            await _repository.AtualizarAsync(ano, cancellation);
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

        public async Task<ICollection<Ano>> ListarAsync(Expression<Func<Ano, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            return await _repository.ListarAsync(condicao, cancellation);
        }
    }
}
