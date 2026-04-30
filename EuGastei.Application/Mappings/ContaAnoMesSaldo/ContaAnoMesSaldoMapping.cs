using AutoMapper;
using EuGastei.Application.DTOs.ContaAnoMesSaldo;
using EuGastei.Domain.Entities;

namespace EuGastei.Application.Mappings.ContaAnoMesSaldo;

public class ContaAnoMesSaldoMapping : Profile
{
    public ContaAnoMesSaldoMapping()
    {
        CreateMap<EuGastei.Domain.Entities.ContaAnoMesSaldo, ContaAnoMesSaldoRespostaDTO>();
    }
}
