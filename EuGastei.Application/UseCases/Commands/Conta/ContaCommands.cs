using EuGastei.Application.DTOs.Conta;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Conta;

public record ContaAdicionarCommand(ContaAdicionarDTO Dto) : IRequest<ContaRespostaDTO>;
public record ContaAtualizarCommand(ContaAtualizarDTO Dto) : IRequest<ContaRespostaDTO>;
public record ContaRemoverCommand(Guid Id) : IRequest<bool>;
