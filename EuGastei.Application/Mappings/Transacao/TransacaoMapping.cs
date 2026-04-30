using AutoMapper;
using EuGastei.Application.DTOs.Transacao;
using EuGastei.Application.UseCases.Commands.Transacao;
using EuGastei.Application.UseCases.Queries.Transacao.Consultar;
using EuGastei.Domain.Entities;
using EuGastei.Domain.QueryObject;

namespace EuGastei.Application.Mappings;

public class TransacaoMapping : Profile
{
    public TransacaoMapping()
    {
        CreateMap<Transacao, TransacaoRespostaDTO>().ReverseMap();
        CreateMap<TransacaoAdicionarDTO, TransacaoAdicionarCommand>().ReverseMap();
        CreateMap<TransacaoAtualizarDTO, TransacaoAtualizarCommand>().ReverseMap();
        CreateMap<TransacaoRemoverDTO, TransacaoRemoverCommand>().ReverseMap();
        CreateMap<TransacaoConsultarDTO, TransacaoConsultarQuery>().ReverseMap();
        CreateMap<TransacaoFiltro, TransacaoConsultarQuery>().ReverseMap();
    }
}
