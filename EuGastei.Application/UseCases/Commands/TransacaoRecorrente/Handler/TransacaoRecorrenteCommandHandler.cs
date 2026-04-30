using AutoMapper;
using EuGastei.Application.DTOs.TransacaoRecorrente;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.TransacaoRecorrente.Handler;

public class TransacaoRecorrenteCommandHandler : IRequestHandler<TransacaoRecorrenteAdicionarCommand, TransacaoRecorrenteRespostaDTO>,
                                                IRequestHandler<TransacaoRecorrenteAtualizarCommand, TransacaoRecorrenteRespostaDTO>,
                                                IRequestHandler<TransacaoRecorrenteRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly ITransacaoRecorrenteRepository _repository;

    public TransacaoRecorrenteCommandHandler(IMapper mapper, ITransacaoRecorrenteRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<TransacaoRecorrenteRespostaDTO> Handle(TransacaoRecorrenteAdicionarCommand request, CancellationToken cancellationToken)
    {
        var entity = EuGastei.Domain.Entities.TransacaoRecorrente.Criar(
            request.Dto.TenantId,
            request.Dto.CategoriaId,
            request.Dto.FormaDePagamentoId,
            request.Dto.ContaId,
            request.Dto.MesInicioId,
            request.Dto.AnoInicioId,
            request.Dto.Dia,
            request.Dto.Valor,
            request.Dto.Descricao,
            request.Dto.Frequencia);

        if (request.Dto.MesFimId.HasValue && request.Dto.AnoFimId.HasValue)
        {
            entity.DefinirFim(request.Dto.MesFimId.Value, request.Dto.AnoFimId.Value);
        }

        await _repository.AdicionarAsync(entity, cancellationToken);
        await _repository.SaveChangesAsync();
        return _mapper.Map<TransacaoRecorrenteRespostaDTO>(entity);
    }

    public async Task<TransacaoRecorrenteRespostaDTO> Handle(TransacaoRecorrenteAtualizarCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.ObterPorIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new Exception("Transação recorrente não encontrada");

        if (request.Dto.MesFimId.HasValue && request.Dto.AnoFimId.HasValue)
        {
            entity.DefinirFim(request.Dto.MesFimId.Value, request.Dto.AnoFimId.Value);
        }

        if (request.Dto.Ativo) entity.Reativar();
        else entity.Desativar();

        await _repository.SaveChangesAsync();
        return _mapper.Map<TransacaoRecorrenteRespostaDTO>(entity);
    }

    public async Task<bool> Handle(TransacaoRecorrenteRemoverCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.ObterPorIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new Exception("Transação recorrente não encontrada");

        await _repository.RemoverAsync(entity, cancellationToken);
        await _repository.SaveChangesAsync();
        return true;
    }
}
