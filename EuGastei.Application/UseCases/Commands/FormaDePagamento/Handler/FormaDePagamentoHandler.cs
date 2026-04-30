using AutoMapper;
using EuGastei.Application.DTOs.FormaDePagamento;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.FormaDePagamento.Handler;

public class FormaDePagamentoHandler : IRequestHandler<FormaDePagamentoAdicionarCommand, FormaDePagamentoRespostaDTO>,
                                        IRequestHandler<FormaDePagamentoAtualizarCommand, FormaDePagamentoRespostaDTO>,
                                        IRequestHandler<FormaDePagamentoRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IFormaDePagamentoRepository _formaDePagamentoRepository;

    public FormaDePagamentoHandler(IMapper mapper, IFormaDePagamentoRepository formaDePagamentoRepository)
    {
        _mapper = mapper;
        _formaDePagamentoRepository = formaDePagamentoRepository;
    }

    public async Task<FormaDePagamentoRespostaDTO> Handle(FormaDePagamentoAdicionarCommand request, CancellationToken cancellationToken)
    {
        var formaDePagamento = FormaDePagamento.Criar(request.TenantId, request.Nome);
        await _formaDePagamentoRepository.AdicionarAsync(formaDePagamento);
        await _formaDePagamentoRepository.SaveChangesAsync();
        return _mapper.Map<FormaDePagamentoRespostaDTO>(formaDePagamento);
    }

    public async Task<FormaDePagamentoRespostaDTO> Handle(FormaDePagamentoAtualizarCommand request, CancellationToken cancellationToken)
    {
        var formaDePagamento = await _formaDePagamentoRepository.ObterPorIdAsync(request.Id);
        if (formaDePagamento == null) throw new Exception("Forma de Pagamento não encontrada");

        formaDePagamento.AtualizarNome(request.Nome);
        await _formaDePagamentoRepository.SaveChangesAsync();
        return _mapper.Map<FormaDePagamentoRespostaDTO>(formaDePagamento);
    }

    public async Task<bool> Handle(FormaDePagamentoRemoverCommand request, CancellationToken cancellationToken)
    {
        var formaDePagamento = await _formaDePagamentoRepository.ObterPorIdAsync(request.Id);
        if (formaDePagamento == null) throw new Exception("Forma de Pagamento não encontrada");

        await _formaDePagamentoRepository.RemoverAsync(formaDePagamento);
        await _formaDePagamentoRepository.SaveChangesAsync();
        return true;
    }
}
