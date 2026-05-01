using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Application.Interfaces;
using System.Linq.Expressions;

namespace EuGastei.Application.Services
{
    public class FormaDePagamentoService : IFormaDePagamentoService
    {
        private readonly IFormaDePagamentoRepository _repository;

        public FormaDePagamentoService(IFormaDePagamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<FormaDePagamento> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await _repository.ObterPorIdAsync(id, cancellation);
        }

        public async Task AdicionarAsync(FormaDePagamento formaDePagamento, CancellationToken cancellation = default)
        {
            await _repository.AdicionarAsync(formaDePagamento, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task AtualizarAsync(FormaDePagamento formaDePagamento, CancellationToken cancellation = default)
        {
            await _repository.AtualizarAsync(formaDePagamento, cancellation);
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

        public async Task<ICollection<FormaDePagamento>> ListarAsync(Expression<Func<FormaDePagamento, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            return await _repository.ListarAsync(condicao, cancellation);
        }
    }
}
