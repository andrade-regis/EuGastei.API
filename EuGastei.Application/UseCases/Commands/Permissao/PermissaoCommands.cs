using EuGastei.Application.DTOs.Permissao;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Permissao;

public record PermissaoAdicionarCommand(Guid TenantId, string Sigla, string Descricao) : IRequest<PermissaoRespostaDTO>;

public record PermissaoAtualizarCommand(Guid Id, string? Sigla, string? Descricao, bool? Ativo) : IRequest<PermissaoRespostaDTO>;

public record PermissaoRemoverCommand(Guid Id) : IRequest<bool>;
