using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Application.Interfaces;
using System.Linq.Expressions;

namespace EuGastei.Application.Services
{
    public class TipoDeTransacaoService : ITipoDeTransacaoService
    {
        private readonly ITipoDeTransacaoRepository _repository;

        public TipoDeTransacaoService(ITipoDeTransacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<TipoDeTransacao> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await _repository.ObterPorIdAsync(id, cancellation);
        }

        public async Task AdicionarAsync(TipoDeTransacao tipoDeTransacao, CancellationToken cancellation = default)
        {
            await _repository.AdicionarAsync(tipoDeTransacao, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task AtualizarAsync(TipoDeTransacao tipoDeTransacao, CancellationToken cancellation = default)
        {
            await _repository.AtualizarAsync(tipoDeTransacao, cancellation);
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

        public async Task<ICollection<TipoDeTransacao>> ListarAsync(Expression<Func<TipoDeTransacao, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            return await _repository.ListarAsync(condicao, cancellation);
        }
    }
}
