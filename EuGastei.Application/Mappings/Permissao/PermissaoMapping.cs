using AutoMapper;
using EuGastei.Application.DTOs.Permissao;
using EuGastei.Application.UseCases.Commands.Permissao;
using EuGastei.Application.UseCases.Queries.Permissao.Consultar;
using EuGastei.Domain.Entities;
using EuGastei.Domain.QueryObject;

namespace EuGastei.Application.Mappings;

public class PermissaoMapping : Profile
{
    public PermissaoMapping()
    {
        CreateMap<Permissao, PermissaoRespostaDTO>().ReverseMap();
        CreateMap<PermissaoAdicionarDTO, PermissaoAdicionarCommand>().ReverseMap();
        CreateMap<PermissaoAtualizarDTO, PermissaoAtualizarCommand>().ReverseMap();
        CreateMap<PermissaoRemoverDTO, PermissaoRemoverCommand>().ReverseMap();
        CreateMap<PermissaoConsultarDTO, PermissaoConsultarQuery>().ReverseMap();
        CreateMap<PermissaoFiltro, PermissaoConsultarQuery>().ReverseMap();
    }
}
