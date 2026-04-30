using AutoMapper;
using EuGastei.Application.DTOs.Perfil;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Perfil.Handler;

public class PerfilHandler : IRequestHandler<PerfilAdicionarCommand, PerfilRespostaDTO>,
                             IRequestHandler<PerfilAtualizarCommand, PerfilRespostaDTO>,
                             IRequestHandler<PerfilRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IPerfilRepository _perfilRepository;

    public PerfilHandler(IMapper mapper, IPerfilRepository perfilRepository)
    {
        _mapper = mapper;
        _perfilRepository = perfilRepository;
    }

    public async Task<PerfilRespostaDTO> Handle(PerfilAdicionarCommand request, CancellationToken cancellationToken)
    {
        var perfil = Domain.Entities.Perfil.Criar(request.TenantId, request.Nome, request.Descricao);
        await _perfilRepository.AdicionarAsync(perfil, cancellationToken);
        await _perfilRepository.SaveChangesAsync();
        return _mapper.Map<PerfilRespostaDTO>(perfil);
    }

    public async Task<PerfilRespostaDTO> Handle(PerfilAtualizarCommand request, CancellationToken cancellationToken)
    {
        var perfil = await _perfilRepository.ObterPorIdAsync(request.Id, cancellationToken);
        if (perfil == null) throw new Exception("Perfil não encontrado");

        if (request.Nome != null) perfil.AtualizarNome(request.Nome);
        if (request.Descricao != null) perfil.AtualizarDescricao(request.Descricao);
        if (request.Ativo.HasValue) perfil.AtualizarAtivo(request.Ativo.Value);

        await _perfilRepository.SaveChangesAsync();
        return _mapper.Map<PerfilRespostaDTO>(perfil);
    }

    public async Task<bool> Handle(PerfilRemoverCommand request, CancellationToken cancellationToken)
    {
        var perfil = await _perfilRepository.ObterPorIdAsync(request.Id, cancellationToken);
        if (perfil == null) throw new Exception("Perfil não encontrado");

        perfil.AtualizarAtivo(false);
        await _perfilRepository.SaveChangesAsync();
        return true;
    }
}
