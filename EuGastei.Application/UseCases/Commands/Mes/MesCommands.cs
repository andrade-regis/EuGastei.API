using EuGastei.Application.DTOs.Mes;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Mes;

public record MesAdicionarCommand(Guid TenantId, int Numero) : IRequest<MesRespostaDTO>;
public record MesAtualizarCommand(Guid Id, int Numero) : IRequest<MesRespostaDTO>;
public record MesRemoverCommand(Guid Id) : IRequest<bool>;
