using EuGastei.Application.DTOs.Tenant;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Tenant;

public record TenantAtualizarCommand(Guid Id, string Nome, bool Ativo) : IRequest<TenantRespostaDTO>;
