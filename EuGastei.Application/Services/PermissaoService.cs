using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Application.Interfaces;
using System.Linq.Expressions;

namespace EuGastei.Application.Services
{
    public class PermissaoService : IPermissaoService
    {
        private readonly IPermissaoRepository _repository;

        public PermissaoService(IPermissaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Permissao> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await _repository.ObterPorIdAsync(id, cancellation);
        }

        public async Task AdicionarAsync(Permissao permissao, CancellationToken cancellation = default)
        {
            await _repository.AdicionarAsync(permissao, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Permissao permissao, CancellationToken cancellation = default)
        {
            await _repository.AtualizarAsync(permissao, cancellation);
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

        public async Task<ICollection<Permissao>> ListarAsync(Expression<Func<Permissao, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            return await _repository.ListarAsync(condicao, cancellation);
        }
    }
}
