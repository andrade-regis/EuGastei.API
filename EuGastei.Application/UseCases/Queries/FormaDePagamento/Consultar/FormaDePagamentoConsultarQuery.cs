using EuGastei.Application.DTOs.FormaDePagamento;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.FormaDePagamento.Consultar;

public record FormaDePagamentoConsultarQuery(Guid? TenantId, string? Nome) : IRequest<IEnumerable<FormaDePagamentoRespostaDTO>>;
