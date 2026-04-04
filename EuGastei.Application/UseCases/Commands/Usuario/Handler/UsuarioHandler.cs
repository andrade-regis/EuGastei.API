using AutoMapper;
using EuGastei.Application.DTOs.Usuario;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Usuario.Handler;

public class UsuarioHandler : IRequestHandler<UsuarioAdicionarCommand, UsuarioRespostaDTO>,
                              IRequestHandler<UsuarioAtualizarCommand, UsuarioRespostaDTO>,
                              IRequestHandler<UsuarioRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ITenantRepository _tenantRepository;

    public UsuarioHandler(IMapper mapper, 
                          IUsuarioRepository usuarioRepository,
                          ITenantRepository tenantRepository)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
        _tenantRepository = tenantRepository;
    }
    
    public async Task<UsuarioRespostaDTO> Handle(UsuarioAdicionarCommand data, 
                                   CancellationToken cancellationToken)
    {
        var tenant = Tenant.Criar("Teste");
        _tenantRepository.Adicionar(tenant);
        
        await _tenantRepository.SaveChangesAsync();
        
        var usuario = Domain.Entities.Usuario.Criar(tenant.Id, 
                                                    tenant.Id,
                                                    data.Nome,
                                                    data.Apelido,
                                                    data.Email,
                                                    data.Senha);
        
        _usuarioRepository.Adicionar(usuario);
        
        await _usuarioRepository.SaveChangesAsync();
        
        return _mapper.Map<UsuarioRespostaDTO>(usuario);
    }

    public async Task<UsuarioRespostaDTO> Handle(UsuarioAtualizarCommand request, 
                                                 CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(request.Id);
        
        if (usuario == null)
            throw new Exception("Usuário informado não encontrado");
        
        if(request.PerfilId.HasValue && request.PerfilId != usuario.PerfilId)
            usuario.AtualizarPerfilId(request.PerfilId.Value);
        
        if(request.Nome is not null && request.Nome != usuario.Nome)
            usuario.AtualizarNome(request.Nome);
        
        if(request.Apelido is not null && request.Apelido != usuario.Apelido)
            usuario.AtualizarApelido(request.Apelido);
        
        if(request.Email is not null && request.Email != usuario.Email)
            usuario.AtualizarEmail(request.Email);
        
        if(request.Senha is not null && request.Senha != usuario.Senha)
            usuario.AtualizarSenha(request.Senha);
            
        await _usuarioRepository.SaveChangesAsync();
        
        return _mapper.Map<UsuarioRespostaDTO>(usuario);
    }

    public async Task<bool> Handle(UsuarioRemoverCommand request, 
                                   CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(request.Id);
        
        if (usuario == null)
            throw new Exception("Usuário informado não encontrado");
        
        usuario.Desativar();
        
        await _usuarioRepository.SaveChangesAsync();
        
        return true;
    }
}