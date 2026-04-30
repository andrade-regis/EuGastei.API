using AutoMapper;
using EuGastei.Application.DTOs.FormaDePagamento;
using EuGastei.Application.UseCases.Commands.FormaDePagamento;
using EuGastei.Application.UseCases.Queries.FormaDePagamento.Consultar;
using EuGastei.Domain.Entities;
using EuGastei.Domain.QueryObject;

namespace EuGastei.Application.Mappings;

public class FormaDePagamentoMapping : Profile
{
    public FormaDePagamentoMapping()
    {
        CreateMap<FormaDePagamento, FormaDePagamentoRespostaDTO>().ReverseMap();
        CreateMap<FormaDePagamentoAdicionarDTO, FormaDePagamentoAdicionarCommand>().ReverseMap();
        CreateMap<FormaDePagamentoAtualizarDTO, FormaDePagamentoAtualizarCommand>().ReverseMap();
        CreateMap<FormaDePagamentoRemoverDTO, FormaDePagamentoRemoverCommand>().ReverseMap();
        CreateMap<FormaDePagamentoConsultarDTO, FormaDePagamentoConsultarQuery>().ReverseMap();
        CreateMap<FormaDePagamentoFiltro, FormaDePagamentoConsultarQuery>().ReverseMap();
    }
}
