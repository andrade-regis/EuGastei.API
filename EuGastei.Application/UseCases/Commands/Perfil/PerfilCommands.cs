using EuGastei.Application.DTOs.Perfil;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Perfil;

public record PerfilAdicionarCommand(Guid TenantId, string Nome, string Descricao) : IRequest<PerfilRespostaDTO>;

public record PerfilAtualizarCommand(Guid Id, string? Nome, string? Descricao, bool? Ativo) : IRequest<PerfilRespostaDTO>;

public record PerfilRemoverCommand(Guid Id) : IRequest<bool>;
