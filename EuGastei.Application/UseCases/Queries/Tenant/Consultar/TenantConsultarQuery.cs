using EuGastei.Application.DTOs.Tenant;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Tenant.Consultar;

public record TenantConsultarQuery(string? Nome, bool? Ativo) : IRequest<IEnumerable<TenantRespostaDTO>>;
