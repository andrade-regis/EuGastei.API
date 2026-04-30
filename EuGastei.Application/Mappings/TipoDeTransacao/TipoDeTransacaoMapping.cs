using AutoMapper;
using EuGastei.Application.DTOs.TipoDeTransacao;
using EuGastei.Application.UseCases.Commands.TipoDeTransacao;
using EuGastei.Application.UseCases.Queries.TipoDeTransacao.Consultar;
using EuGastei.Domain.Entities;
using EuGastei.Domain.QueryObject;

namespace EuGastei.Application.Mappings;

public class TipoDeTransacaoMapping : Profile
{
    public TipoDeTransacaoMapping()
    {
        CreateMap<TipoDeTransacao, TipoDeTransacaoRespostaDTO>().ReverseMap();
        CreateMap<TipoDeTransacaoAdicionarDTO, TipoDeTransacaoAdicionarCommand>().ReverseMap();
        CreateMap<TipoDeTransacaoAtualizarDTO, TipoDeTransacaoAtualizarCommand>().ReverseMap();
        CreateMap<TipoDeTransacaoRemoverDTO, TipoDeTransacaoRemoverCommand>().ReverseMap();
        CreateMap<TipoDeTransacaoConsultarDTO, TipoDeTransacaoConsultarQuery>().ReverseMap();
        CreateMap<TipoDeTransacaoFiltro, TipoDeTransacaoConsultarQuery>().ReverseMap();
    }
}
