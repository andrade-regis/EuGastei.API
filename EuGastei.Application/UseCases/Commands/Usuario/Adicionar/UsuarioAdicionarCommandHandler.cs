using AutoMapper;
using EuGastei.Application.DTOs.Usuario;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Usuario.Adicionar;

public class UsuarioAdicionarCommandHandler : IRequestHandler<UsuarioAdicionarCommand, UsuarioRespostaDTO>
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ITenantRepository _tenantRepository;
    
    public UsuarioAdicionarCommandHandler(IMapper mapper, 
                                          IUsuarioRepository usuarioRepository,
                                          ITenantRepository tenantRepository)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
        _tenantRepository = tenantRepository;
    }
    
    public async Task<UsuarioRespostaDTO> Handle(UsuarioAdicionarCommand data, CancellationToken cancellationToken)
    {
        var tenant = Domain.Entities.Tenant.Criar("Teste");
        
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
}