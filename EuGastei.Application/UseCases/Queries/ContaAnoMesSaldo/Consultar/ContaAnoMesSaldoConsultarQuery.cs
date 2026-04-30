using EuGastei.Application.DTOs.ContaAnoMesSaldo;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.ContaAnoMesSaldo.Consultar;

public record ContaAnoMesSaldoConsultarQuery(ContaAnoMesSaldoConsultarDTO Filtro) : IRequest<IEnumerable<ContaAnoMesSaldoRespostaDTO>>;
