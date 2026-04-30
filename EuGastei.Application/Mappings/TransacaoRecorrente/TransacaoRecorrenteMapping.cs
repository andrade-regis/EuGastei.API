using AutoMapper;
using EuGastei.Application.DTOs.TransacaoRecorrente;
using EuGastei.Domain.Entities;

namespace EuGastei.Application.Mappings.TransacaoRecorrente;

public class TransacaoRecorrenteMapping : Profile
{
    public TransacaoRecorrenteMapping()
    {
        CreateMap<EuGastei.Domain.Entities.TransacaoRecorrente, TransacaoRecorrenteRespostaDTO>();
    }
}
