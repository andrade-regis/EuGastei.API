using AutoMapper;
using EuGastei.Application.DTOs.Transacao;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Transacao.Handler;

public class TransacaoHandler : IRequestHandler<TransacaoAdicionarCommand, TransacaoRespostaDTO>,
                               IRequestHandler<TransacaoAtualizarCommand, TransacaoRespostaDTO>,
                               IRequestHandler<TransacaoRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly ITransacaoRepository _transacaoRepository;

    public TransacaoHandler(IMapper mapper, ITransacaoRepository transacaoRepository)
    {
        _mapper = mapper;
        _transacaoRepository = transacaoRepository;
    }

    public async Task<TransacaoRespostaDTO> Handle(TransacaoAdicionarCommand request, CancellationToken cancellationToken)
    {
        var transacao = Domain.Entities.Transacao.Criar(
            request.TenantId,
            request.CategoriaId,
            request.FormaDePagamentoId,
            request.ContaId,
            request.AnoId,
            request.MesId,
            request.Dia,
            request.Descricao,
            request.Valor,
            request.Status,
            request.OrigemRecorrenciaId);

        await _transacaoRepository.AdicionarAsync(transacao, cancellationToken);
        await _transacaoRepository.SaveChangesAsync();

        return _mapper.Map<TransacaoRespostaDTO>(transacao);
    }

    public async Task<TransacaoRespostaDTO> Handle(TransacaoAtualizarCommand request, CancellationToken cancellationToken)
    {
        var transacao = await _transacaoRepository.ObterPorIdAsync(request.Id, cancellationToken);
        if (transacao == null) throw new Exception("Transação não encontrada");

        if (request.CategoriaId.HasValue) transacao.AtualizarCategoriaId(request.CategoriaId.Value);
        if (request.FormaDePagamentoId.HasValue) transacao.AtualizarFormaDePagamentoId(request.FormaDePagamentoId.Value);
        if (request.ContaId.HasValue) transacao.AtualizarContaId(request.ContaId.Value);
        if (request.AnoId.HasValue) transacao.AtualizarAnoId(request.AnoId.Value);
        if (request.MesId.HasValue) transacao.AtualizarMesId(request.MesId.Value);
        if (request.Dia.HasValue) transacao.AtualizarDia(request.Dia.Value);
        if (request.Descricao != null) transacao.AtualizarDescricao(request.Descricao);
        if (request.Valor.HasValue) transacao.AtualizarValor(request.Valor.Value);
        if (request.Status.HasValue) transacao.AlterarStatus(request.Status.Value);
        if (request.OrigemRecorrenciaId.HasValue) transacao.AtualizarOrigemRecorrenciaId(request.OrigemRecorrenciaId.Value);

        await _transacaoRepository.SaveChangesAsync();

        return _mapper.Map<TransacaoRespostaDTO>(transacao);
    }

    public async Task<bool> Handle(TransacaoRemoverCommand request, CancellationToken cancellationToken)
    {
        var transacao = await _transacaoRepository.ObterPorIdAsync(request.Id, cancellationToken);
        if (transacao == null) throw new Exception("Transação não encontrada");

        await _transacaoRepository.RemoverAsync(transacao, cancellationToken);
        await _transacaoRepository.SaveChangesAsync();

        return true;
    }
}
