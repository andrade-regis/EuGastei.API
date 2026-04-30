using EuGastei.Application.DTOs.TransacaoRecorrente;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.TransacaoRecorrente;

public record TransacaoRecorrenteAdicionarCommand(TransacaoRecorrenteAdicionarDTO Dto) : IRequest<TransacaoRecorrenteRespostaDTO>;
public record TransacaoRecorrenteAtualizarCommand(TransacaoRecorrenteAtualizarDTO Dto) : IRequest<TransacaoRecorrenteRespostaDTO>;
public record TransacaoRecorrenteRemoverCommand(Guid Id) : IRequest<bool>;
