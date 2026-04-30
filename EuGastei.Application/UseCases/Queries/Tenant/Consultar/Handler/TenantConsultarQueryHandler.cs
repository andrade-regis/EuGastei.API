using AutoMapper;
using EuGastei.Application.DTOs.Tenant;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Tenant.Consultar.Handler;

public class TenantConsultarQueryHandler : IRequestHandler<TenantConsultarQuery, IEnumerable<TenantRespostaDTO>>
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IMapper _mapper;

    public TenantConsultarQueryHandler(ITenantRepository tenantRepository, IMapper mapper)
    {
        _tenantRepository = tenantRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TenantRespostaDTO>> Handle(TenantConsultarQuery request, CancellationToken cancellationToken)
    {
        var tenants = await _tenantRepository.ListarAsync(x => 
            (string.IsNullOrEmpty(request.Nome) || x.Nome.Contains(request.Nome)) &&
            (!request.Ativo.HasValue || x.Ativo == request.Ativo.Value));
            
        return _mapper.Map<IEnumerable<TenantRespostaDTO>>(tenants);
    }
}
