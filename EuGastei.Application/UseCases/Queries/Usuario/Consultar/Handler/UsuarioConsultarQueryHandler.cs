using System.Linq;
using AutoMapper;
using EuGastei.Application.DTOs.Usuario;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Usuario.Consultar.Handler;

public class UsuarioConsultarQueryHandler : IRequestHandler<UsuarioConsultarQuery, ICollection<UsuarioRespostaDTO>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuarioConsultarQueryHandler(IUsuarioRepository usuarioRepository,
                                        IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }
    
    public async Task<ICollection<UsuarioRespostaDTO>> Handle(UsuarioConsultarQuery request, 
                                                       CancellationToken cancellationToken)
    {
        var consultarUsuarios = _usuarioRepository.ListarByQueryable();
        
        if (request.Id.HasValue)
        {
            consultarUsuarios = consultarUsuarios.Where(x => x.Id == request.Id.Value);

            var result = await consultarUsuarios.ToListAsync();
            
            return _mapper.Map<ICollection<UsuarioRespostaDTO>>(result); 
        }

        if (request.PerfilId.HasValue)
            consultarUsuarios = consultarUsuarios.Where(x => x.PerfilId == request.PerfilId);
        
        if(request.Nome is not null)
            consultarUsuarios = consultarUsuarios.Where(x => x.Nome == request.Nome);

        if (request.Apelido is not null)
            consultarUsuarios = consultarUsuarios.Where(x => x.Apelido == request.Apelido);

        if (request.Email is not null)
            consultarUsuarios = consultarUsuarios.Where(x => x.Email == request.Email);

        if (request.Ativo is not null)
            consultarUsuarios = consultarUsuarios.Where(x => x.Ativo == request.Ativo);

        var result = await consultarUsuarios.ToListAsync();
        
        return _mapper.Map<ICollection<UsuarioRespostaDTO>>(result);
    }
}