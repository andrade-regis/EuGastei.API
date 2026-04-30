using EuGastei.Application.DTOs.Ano;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Ano;

public record AnoAdicionarCommand(Guid TenantId, int Numero) : IRequest<AnoRespostaDTO>;
public record AnoAtualizarCommand(Guid Id, int Numero) : IRequest<AnoRespostaDTO>;
public record AnoRemoverCommand(Guid Id) : IRequest<bool>;
