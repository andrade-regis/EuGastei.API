using EuGastei.Application.DTOs.Transacao;
using EuGastei.Domain.Enums;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Transacao;

public record TransacaoAdicionarCommand(
    Guid TenantId,
    Guid CategoriaId,
    Guid FormaDePagamentoId,
    Guid ContaId,
    Guid AnoId,
    Guid MesId,
    int Dia,
    string Descricao,
    decimal Valor,
    EStatusTransacao Status,
    Guid? OrigemRecorrenciaId = null) : IRequest<TransacaoRespostaDTO>;

public record TransacaoAtualizarCommand(
    Guid Id,
    Guid? CategoriaId,
    Guid? FormaDePagamentoId,
    Guid? ContaId,
    Guid? AnoId,
    Guid? MesId,
    int? Dia,
    string? Descricao,
    decimal? Valor,
    EStatusTransacao? Status,
    Guid? OrigemRecorrenciaId) : IRequest<TransacaoRespostaDTO>;

public record TransacaoRemoverCommand(Guid Id) : IRequest<bool>;
