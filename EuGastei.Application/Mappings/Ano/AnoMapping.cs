using AutoMapper;
using EuGastei.Application.DTOs.Ano;
using EuGastei.Application.UseCases.Commands.Ano;
using EuGastei.Application.UseCases.Queries.Ano.Consultar;
using EuGastei.Domain.Entities;
using EuGastei.Domain.QueryObject;

namespace EuGastei.Application.Mappings;

public class AnoMapping : Profile
{
    public AnoMapping()
    {
        CreateMap<Ano, AnoRespostaDTO>().ReverseMap();
        CreateMap<AnoAdicionarDTO, AnoAdicionarCommand>().ReverseMap();
        CreateMap<AnoAtualizarDTO, AnoAtualizarCommand>().ReverseMap();
        CreateMap<AnoRemoverDTO, AnoRemoverCommand>().ReverseMap();
        CreateMap<AnoConsultarDTO, AnoConsultarQuery>().ReverseMap();
        CreateMap<AnoFiltro, AnoConsultarQuery>().ReverseMap();
    }
}
