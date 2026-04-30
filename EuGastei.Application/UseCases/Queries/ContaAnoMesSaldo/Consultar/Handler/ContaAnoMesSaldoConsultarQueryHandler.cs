using AutoMapper;
using EuGastei.Application.DTOs.ContaAnoMesSaldo;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.ContaAnoMesSaldo.Consultar.Handler;

public class ContaAnoMesSaldoConsultarQueryHandler : IRequestHandler<ContaAnoMesSaldoConsultarQuery, IEnumerable<ContaAnoMesSaldoRespostaDTO>>
{
    private readonly IContaAnoMesSaldoRepository _contaAnoMesSaldoRepository;
    private readonly IMapper _mapper;

    public ContaAnoMesSaldoConsultarQueryHandler(IContaAnoMesSaldoRepository repository, IMapper mapper)
    {
        _contaAnoMesSaldoRepository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContaAnoMesSaldoRespostaDTO>> Handle(ContaAnoMesSaldoConsultarQuery request, CancellationToken cancellationToken)
    {
        var results = await _contaAnoMesSaldoRepository.ListarAsync(c =>
            (!request.Filtro.TenantId.HasValue || c.TenantId == request.Filtro.TenantId.Value) &&
            (!request.Filtro.ContaId.HasValue || c.ContaId == request.Filtro.ContaId.Value) &&
            (!request.Filtro.AnoId.HasValue || c.AnoId == request.Filtro.AnoId.Value) &&
            (!request.Filtro.MesId.HasValue || c.MesId == request.Filtro.MesId.Value),
            cancellationToken);

        return _mapper.Map<IEnumerable<ContaAnoMesSaldoRespostaDTO>>(results);
    }
}
