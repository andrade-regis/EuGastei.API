using AutoMapper;
using EuGastei.Application.DTOs.Mes;
using EuGastei.Application.UseCases.Commands.Mes;
using EuGastei.Application.UseCases.Queries.Mes.Consultar;
using EuGastei.Domain.Entities;
using EuGastei.Domain.QueryObject;

namespace EuGastei.Application.Mappings;

public class MesMapping : Profile
{
    public MesMapping()
    {
        CreateMap<Mes, MesRespostaDTO>().ReverseMap();
        CreateMap<MesAdicionarDTO, MesAdicionarCommand>().ReverseMap();
        CreateMap<MesAtualizarDTO, MesAtualizarCommand>().ReverseMap();
        CreateMap<MesRemoverDTO, MesRemoverCommand>().ReverseMap();
        CreateMap<MesConsultarDTO, MesConsultarQuery>().ReverseMap();
        CreateMap<MesFiltro, MesConsultarQuery>().ReverseMap();
    }
}
