using EuGastei.Application.DTOs.Transacao;
using EuGastei.Domain.Enums;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Transacao.Consultar;

public record TransacaoConsultarQuery(
    Guid? TenantId,
    Guid? CategoriaId,
    Guid? FormaDePagamentoId,
    Guid? ContaId,
    Guid? AnoId,
    Guid? MesId,
    EStatusTransacao? Status) : IRequest<IEnumerable<TransacaoRespostaDTO>>;
