using EuGastei.Application.DTOs.TransacaoRecorrente;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.TransacaoRecorrente.Consultar;

public record TransacaoRecorrenteConsultarQuery(TransacaoRecorrenteConsultarDTO Filtro) : IRequest<IEnumerable<TransacaoRecorrenteRespostaDTO>>;
