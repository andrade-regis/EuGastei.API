using EuGastei.Application.DTOs.Mes;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Mes.Consultar;

public record MesConsultarQuery(Guid? TenantId, int? Numero) : IRequest<IEnumerable<MesRespostaDTO>>;
