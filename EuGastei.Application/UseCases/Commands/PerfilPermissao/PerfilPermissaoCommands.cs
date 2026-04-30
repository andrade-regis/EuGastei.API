using EuGastei.Application.DTOs.PerfilPermissao;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.PerfilPermissao;

public record PerfilPermissaoAdicionarCommand(Guid TenantId, Guid PerfilId, Guid PermissaoId) : IRequest<PerfilPermissaoRespostaDTO>;

public record PerfilPermissaoAtualizarCommand(Guid Id, Guid? PerfilId, Guid? PermissaoId) : IRequest<PerfilPermissaoRespostaDTO>;

public record PerfilPermissaoRemoverCommand(Guid Id) : IRequest<bool>;
