using AutoMapper;
using EuGastei.Application.DTOs.Perfil;
using EuGastei.Application.UseCases.Commands.Perfil;
using EuGastei.Application.UseCases.Queries.Perfil.Consultar;
using EuGastei.Domain.Entities;
using EuGastei.Domain.QueryObject;

namespace EuGastei.Application.Mappings;

public class PerfilMapping : Profile
{
    public PerfilMapping()
    {
        CreateMap<Perfil, PerfilRespostaDTO>().ReverseMap();
        CreateMap<PerfilAdicionarDTO, PerfilAdicionarCommand>().ReverseMap();
        CreateMap<PerfilAtualizarDTO, PerfilAtualizarCommand>().ReverseMap();
        CreateMap<PerfilRemoverDTO, PerfilRemoverCommand>().ReverseMap();
        CreateMap<PerfilConsultarDTO, PerfilConsultarQuery>().ReverseMap();
        CreateMap<PerfilFiltro, PerfilConsultarQuery>().ReverseMap();
    }
}
