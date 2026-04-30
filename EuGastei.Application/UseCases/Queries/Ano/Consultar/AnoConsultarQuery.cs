using EuGastei.Application.DTOs.Ano;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Ano.Consultar;

public record AnoConsultarQuery(Guid? TenantId, int? Numero) : IRequest<IEnumerable<AnoRespostaDTO>>;
