using EuGastei.Application.DTOs.TipoDeTransacao;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.TipoDeTransacao.Consultar;

public record TipoDeTransacaoConsultarQuery(TipoDeTransacaoConsultarDTO Filtro) : IRequest<IEnumerable<TipoDeTransacaoRespostaDTO>>;
