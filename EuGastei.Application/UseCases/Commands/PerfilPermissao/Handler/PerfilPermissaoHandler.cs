using AutoMapper;
using EuGastei.Application.DTOs.PerfilPermissao;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.PerfilPermissao.Handler;

public class PerfilPermissaoHandler : IRequestHandler<PerfilPermissaoAdicionarCommand, PerfilPermissaoRespostaDTO>,
                                      IRequestHandler<PerfilPermissaoAtualizarCommand, PerfilPermissaoRespostaDTO>,
                                      IRequestHandler<PerfilPermissaoRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IPerfilPermissaoRepository _perfilPermissaoRepository;

    public PerfilPermissaoHandler(IMapper mapper, IPerfilPermissaoRepository perfilPermissaoRepository)
    {
        _mapper = mapper;
        _perfilPermissaoRepository = perfilPermissaoRepository;
    }

    public async Task<PerfilPermissaoRespostaDTO> Handle(PerfilPermissaoAdicionarCommand request, CancellationToken cancellationToken)
    {
        var perfilPermissao = Domain.Entities.PerfilPermissao.Criar(request.TenantId, request.PerfilId, request.PermissaoId);
        await _perfilPermissaoRepository.AdicionarAsync(perfilPermissao, cancellationToken);
        await _perfilPermissaoRepository.SaveChangesAsync();
        return _mapper.Map<PerfilPermissaoRespostaDTO>(perfilPermissao);
    }

    public async Task<PerfilPermissaoRespostaDTO> Handle(PerfilPermissaoAtualizarCommand request, CancellationToken cancellationToken)
    {
        var perfilPermissao = await _perfilPermissaoRepository.ObterPorIdAsync(request.Id, cancellationToken);
        if (perfilPermissao == null) throw new Exception("PerfilPermissao não encontrado");

        if (request.PerfilId.HasValue) perfilPermissao.AtualizarPerfilId(request.PerfilId.Value);
        if (request.PermissaoId.HasValue) perfilPermissao.AtualizarPermissaoId(request.PermissaoId.Value);

        await _perfilPermissaoRepository.SaveChangesAsync();
        return _mapper.Map<PerfilPermissaoRespostaDTO>(perfilPermissao);
    }

    public async Task<bool> Handle(PerfilPermissaoRemoverCommand request, CancellationToken cancellationToken)
    {
        var perfilPermissao = await _perfilPermissaoRepository.ObterPorIdAsync(request.Id, cancellationToken);
        if (perfilPermissao == null) throw new Exception("PerfilPermissao não encontrado");

        await _perfilPermissaoRepository.RemoverAsync(perfilPermissao, cancellationToken);
        await _perfilPermissaoRepository.SaveChangesAsync();
        return true;
    }
}
