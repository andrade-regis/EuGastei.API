using MediatR;

namespace EuGastei.Application.UseCases.Commands.Tenant;

public record TenantRemoverCommand(Guid Id) : IRequest<bool>;
