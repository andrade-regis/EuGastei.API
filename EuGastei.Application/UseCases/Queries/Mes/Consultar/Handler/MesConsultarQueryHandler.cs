using AutoMapper;
using EuGastei.Application.DTOs.Mes;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Mes.Consultar.Handler;

public class MesConsultarQueryHandler : IRequestHandler<MesConsultarQuery, IEnumerable<MesRespostaDTO>>
{
    private readonly IMesRepository _mesRepository;
    private readonly IMapper _mapper;

    public MesConsultarQueryHandler(IMesRepository mesRepository, IMapper mapper)
    {
        _mesRepository = mesRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MesRespostaDTO>> Handle(MesConsultarQuery request, CancellationToken cancellationToken)
    {
        var meses = await _mesRepository.ListarAsync(x => 
            (!request.TenantId.HasValue || x.TenantId == request.TenantId.Value) &&
            (!request.Numero.HasValue || x.Numero == request.Numero.Value));
            
        return _mapper.Map<IEnumerable<MesRespostaDTO>>(meses);
    }
}
