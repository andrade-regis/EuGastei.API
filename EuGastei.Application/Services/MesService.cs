using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Application.Interfaces;
using System.Linq.Expressions;

namespace EuGastei.Application.Services
{
    public class MesService : IMesService
    {
        private readonly IMesRepository _repository;

        public MesService(IMesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Mes> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await _repository.ObterPorIdAsync(id, cancellation);
        }

        public async Task AdicionarAsync(Mes mes, CancellationToken cancellation = default)
        {
            await _repository.AdicionarAsync(mes, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Mes mes, CancellationToken cancellation = default)
        {
            await _repository.AtualizarAsync(mes, cancellation);
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

        public async Task<ICollection<Mes>> ListarAsync(Expression<Func<Mes, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            return await _repository.ListarAsync(condicao, cancellation);
        }
    }
}
