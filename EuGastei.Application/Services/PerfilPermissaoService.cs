using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Application.Interfaces;
using System.Linq.Expressions;

namespace EuGastei.Application.Services
{
    public class PerfilPermissaoService : IPerfilPermissaoService
    {
        private readonly IPerfilPermissaoRepository _repository;

        public PerfilPermissaoService(IPerfilPermissaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PerfilPermissao> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await _repository.ObterPorIdAsync(id, cancellation);
        }

        public async Task AdicionarAsync(PerfilPermissao perfilPermissao, CancellationToken cancellation = default)
        {
            await _repository.AdicionarAsync(perfilPermissao, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task AtualizarAsync(PerfilPermissao perfilPermissao, CancellationToken cancellation = default)
        {
            await _repository.AtualizarAsync(perfilPermissao, cancellation);
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

        public async Task<ICollection<PerfilPermissao>> ListarAsync(Expression<Func<PerfilPermissao, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            return await _repository.ListarAsync(condicao, cancellation);
        }
    }
}
