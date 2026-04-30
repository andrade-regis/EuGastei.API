using EuGastei.Application.DTOs.Tenant;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Tenant;

public record TenantAdicionarCommand(string Nome) : IRequest<TenantRespostaDTO>;
