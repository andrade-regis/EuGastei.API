using AutoMapper;
using EuGastei.Application.DTOs.TipoDeTransacao;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.TipoDeTransacao.Handler;

public class TipoDeTransacaoHandler : IRequestHandler<TipoDeTransacaoAdicionarCommand, TipoDeTransacaoRespostaDTO>,
                                      IRequestHandler<TipoDeTransacaoAtualizarCommand, TipoDeTransacaoRespostaDTO>,
                                      IRequestHandler<TipoDeTransacaoRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly ITipoDeTransacaoRepository _tipoDeTransacaoRepository;

    public TipoDeTransacaoHandler(IMapper mapper, ITipoDeTransacaoRepository tipoDeTransacaoRepository)
    {
        _mapper = mapper;
        _tipoDeTransacaoRepository = tipoDeTransacaoRepository;
    }

    public async Task<TipoDeTransacaoRespostaDTO> Handle(TipoDeTransacaoAdicionarCommand request, CancellationToken cancellationToken)
    {
        var tipoDeTransacao = TipoDeTransacao.Criar(request.Dto.TenantId, request.Dto.Nome);
        await _tipoDeTransacaoRepository.AdicionarAsync(tipoDeTransacao);
        await _tipoDeTransacaoRepository.SaveChangesAsync();
        return _mapper.Map<TipoDeTransacaoRespostaDTO>(tipoDeTransacao);
    }

    public async Task<TipoDeTransacaoRespostaDTO> Handle(TipoDeTransacaoAtualizarCommand request, CancellationToken cancellationToken)
    {
        var tipoDeTransacao = await _tipoDeTransacaoRepository.ObterPorIdAsync(request.Dto.Id);
        if (tipoDeTransacao == null) throw new Exception("Tipo de transação não encontrado");

        tipoDeTransacao.AtualizarNome(request.Dto.Nome);
        
        if (request.Dto.Ativo) tipoDeTransacao.Ativar();
        else tipoDeTransacao.Desativar();

        await _tipoDeTransacaoRepository.SaveChangesAsync();
        return _mapper.Map<TipoDeTransacaoRespostaDTO>(tipoDeTransacao);
    }

    public async Task<bool> Handle(TipoDeTransacaoRemoverCommand request, CancellationToken cancellationToken)
    {
        var tipoDeTransacao = await _tipoDeTransacaoRepository.ObterPorIdAsync(request.Id);
        if (tipoDeTransacao == null) throw new Exception("Tipo de transação não encontrado");

        await _tipoDeTransacaoRepository.RemoverAsync(tipoDeTransacao);
        await _tipoDeTransacaoRepository.SaveChangesAsync();
        return true;
    }
}
