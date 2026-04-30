using AutoMapper;
using EuGastei.Application.DTOs.Usuario;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Domain.QueryObject;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Usuario.Consultar.Handler;

public class UsuarioConsultarQueryHandler : IRequestHandler<UsuarioConsultarQuery, IEnumerable<UsuarioRespostaResponse>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuarioConsultarQueryHandler(IUsuarioRepository usuarioRepository,
                                        IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<UsuarioRespostaResponse>> Handle(UsuarioConsultarQuery request, 
                                                       CancellationToken cancellationToken)
    {
        var usuarioFiltro = _mapper.Map<UsuarioFiltro>(request);
        
        return _mapper.Map<ICollection<UsuarioRespostaResponse>>(_usuarioRepository.ListarPorFiltro(usuarioFiltro));
    }
}