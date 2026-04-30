using AutoMapper;
using EuGastei.Application.DTOs.Ano;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Ano.Consultar.Handler;

public class AnoConsultarQueryHandler : IRequestHandler<AnoConsultarQuery, IEnumerable<AnoRespostaDTO>>
{
    private readonly IAnoRepository _anoRepository;
    private readonly IMapper _mapper;

    public AnoConsultarQueryHandler(IAnoRepository anoRepository, IMapper mapper)
    {
        _anoRepository = anoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AnoRespostaDTO>> Handle(AnoConsultarQuery request, CancellationToken cancellationToken)
    {
        var anos = await _anoRepository.ListarAsync(x => 
            (!request.TenantId.HasValue || x.TenantId == request.TenantId.Value) &&
            (!request.Numero.HasValue || x.Numero == request.Numero.Value));
            
        return _mapper.Map<IEnumerable<AnoRespostaDTO>>(anos);
    }
}
