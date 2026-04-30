using AutoMapper;
using EuGastei.Application.DTOs.Conta;
using EuGastei.Domain.Entities;

namespace EuGastei.Application.Mappings.Conta;

public class ContaMapping : Profile
{
    public ContaMapping()
    {
        CreateMap<EuGastei.Domain.Entities.Conta, ContaRespostaDTO>();
    }
}
