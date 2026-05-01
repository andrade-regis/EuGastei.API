using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Application.Interfaces;
using System.Linq.Expressions;

namespace EuGastei.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _repository;

        public TenantService(ITenantRepository repository)
        {
            _repository = repository;
        }

        public async Task<Tenant> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await _repository.ObterPorIdAsync(id, cancellation);
        }

        public async Task AdicionarAsync(Tenant tenant, CancellationToken cancellation = default)
        {
            await _repository.AdicionarAsync(tenant, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Tenant tenant, CancellationToken cancellation = default)
        {
            await _repository.AtualizarAsync(tenant, cancellation);
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

        public async Task<ICollection<Tenant>> ListarAsync(Expression<Func<Tenant, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            return await _repository.ListarAsync(condicao, cancellation);
        }
    }
}
