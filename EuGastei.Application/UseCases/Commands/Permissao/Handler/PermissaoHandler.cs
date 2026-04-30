using AutoMapper;
using EuGastei.Application.DTOs.Permissao;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Permissao.Handler;

public class PermissaoHandler : IRequestHandler<PermissaoAdicionarCommand, PermissaoRespostaDTO>,
                                IRequestHandler<PermissaoAtualizarCommand, PermissaoRespostaDTO>,
                                IRequestHandler<PermissaoRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IPermissaoRepository _permissaoRepository;

    public PermissaoHandler(IMapper mapper, IPermissaoRepository permissaoRepository)
    {
        _mapper = mapper;
        _permissaoRepository = permissaoRepository;
    }

    public async Task<PermissaoRespostaDTO> Handle(PermissaoAdicionarCommand request, CancellationToken cancellationToken)
    {
        var permissao = Domain.Entities.Permissao.Criar(request.TenantId, request.Sigla, request.Descricao);
        await _permissaoRepository.AdicionarAsync(permissao, cancellationToken);
        await _permissaoRepository.SaveChangesAsync();
        return _mapper.Map<PermissaoRespostaDTO>(permissao);
    }

    public async Task<PermissaoRespostaDTO> Handle(PermissaoAtualizarCommand request, CancellationToken cancellationToken)
    {
        var permissao = await _permissaoRepository.ObterPorIdAsync(request.Id, cancellationToken);
        if (permissao == null) throw new Exception("Permissão não encontrada");

        if (request.Sigla != null) permissao.AtualizarSigla(request.Sigla);
        if (request.Descricao != null) permissao.AtualizarDescricao(request.Descricao);
        if (request.Ativo.HasValue) permissao.AtualizarAtivo(request.Ativo.Value);

        await _permissaoRepository.SaveChangesAsync();
        return _mapper.Map<PermissaoRespostaDTO>(permissao);
    }

    public async Task<bool> Handle(PermissaoRemoverCommand request, CancellationToken cancellationToken)
    {
        var permissao = await _permissaoRepository.ObterPorIdAsync(request.Id, cancellationToken);
        if (permissao == null) throw new Exception("Permissão não encontrada");

        permissao.AtualizarAtivo(false);
        await _permissaoRepository.SaveChangesAsync();
        return true;
    }
}
