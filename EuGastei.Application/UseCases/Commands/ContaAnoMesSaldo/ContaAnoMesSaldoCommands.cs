using EuGastei.Application.DTOs.ContaAnoMesSaldo;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.ContaAnoMesSaldo;

public record ContaAnoMesSaldoAdicionarCommand(ContaAnoMesSaldoAdicionarDTO Dto) : IRequest<ContaAnoMesSaldoRespostaDTO>;
public record ContaAnoMesSaldoAtualizarCommand(ContaAnoMesSaldoAtualizarDTO Dto) : IRequest<ContaAnoMesSaldoRespostaDTO>;
public record ContaAnoMesSaldoRemoverCommand(Guid Id) : IRequest<bool>;
