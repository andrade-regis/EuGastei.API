using EuGastei.Application.DTOs.TipoDeTransacao;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.TipoDeTransacao;

public record TipoDeTransacaoAdicionarCommand(TipoDeTransacaoAdicionarDTO Dto) : IRequest<TipoDeTransacaoRespostaDTO>;
public record TipoDeTransacaoAtualizarCommand(TipoDeTransacaoAtualizarDTO Dto) : IRequest<TipoDeTransacaoRespostaDTO>;
public record TipoDeTransacaoRemoverCommand(Guid Id) : IRequest<bool>;
