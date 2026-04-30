using AutoMapper;
using EuGastei.Application.DTOs.Tenant;
using EuGastei.Application.UseCases.Commands.Tenant;
using EuGastei.Application.UseCases.Queries.Tenant.Consultar;
using EuGastei.Domain.Entities;
using EuGastei.Domain.QueryObject;

namespace EuGastei.Application.Mappings;

public class TenantMapping : Profile
{
    public TenantMapping()
    {
        CreateMap<Tenant, TenantRespostaDTO>().ReverseMap();
        CreateMap<TenantAdicionarDTO, TenantAdicionarCommand>().ReverseMap();
        CreateMap<TenantAtualizarDTO, TenantAtualizarCommand>().ReverseMap();
        CreateMap<TenantRemoverDTO, TenantRemoverCommand>().ReverseMap();
        CreateMap<TenantConsultarDTO, TenantConsultarQuery>().ReverseMap();
        CreateMap<TenantFiltro, TenantConsultarQuery>().ReverseMap();
    }
}
