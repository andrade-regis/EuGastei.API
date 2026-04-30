using AutoMapper;
using EuGastei.Application.DTOs.PerfilPermissao;
using EuGastei.Application.UseCases.Commands.PerfilPermissao;
using EuGastei.Application.UseCases.Queries.PerfilPermissao.Consultar;
using EuGastei.Domain.Entities;
using EuGastei.Domain.QueryObject;

namespace EuGastei.Application.Mappings;

public class PerfilPermissaoMapping : Profile
{
    public PerfilPermissaoMapping()
    {
        CreateMap<PerfilPermissao, PerfilPermissaoRespostaDTO>().ReverseMap();
        CreateMap<PerfilPermissaoAdicionarDTO, PerfilPermissaoAdicionarCommand>().ReverseMap();
        CreateMap<PerfilPermissaoAtualizarDTO, PerfilPermissaoAtualizarCommand>().ReverseMap();
        CreateMap<PerfilPermissaoRemoverDTO, PerfilPermissaoRemoverCommand>().ReverseMap();
        CreateMap<PerfilPermissaoConsultarDTO, PerfilPermissaoConsultarQuery>().ReverseMap();
        CreateMap<PerfilPermissaoFiltro, PerfilPermissaoConsultarQuery>().ReverseMap();
    }
}
