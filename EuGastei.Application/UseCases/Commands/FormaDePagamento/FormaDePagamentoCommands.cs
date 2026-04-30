using EuGastei.Application.DTOs.FormaDePagamento;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.FormaDePagamento;

public record FormaDePagamentoAdicionarCommand(Guid TenantId, string Nome) : IRequest<FormaDePagamentoRespostaDTO>;
public record FormaDePagamentoAtualizarCommand(Guid Id, string Nome) : IRequest<FormaDePagamentoRespostaDTO>;
public record FormaDePagamentoRemoverCommand(Guid Id) : IRequest<bool>;
