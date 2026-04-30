using AutoMapper;
using EuGastei.Application.DTOs.ContaAnoMesSaldo;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.ContaAnoMesSaldo.Handler;

public class ContaAnoMesSaldoCommandHandler : IRequestHandler<ContaAnoMesSaldoAdicionarCommand, ContaAnoMesSaldoRespostaDTO>,
                                             IRequestHandler<ContaAnoMesSaldoAtualizarCommand, ContaAnoMesSaldoRespostaDTO>,
                                             IRequestHandler<ContaAnoMesSaldoRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IContaAnoMesSaldoRepository _contaAnoMesSaldoRepository;

    public ContaAnoMesSaldoCommandHandler(IMapper mapper, IContaAnoMesSaldoRepository repository)
    {
        _mapper = mapper;
        _contaAnoMesSaldoRepository = repository;
    }

    public async Task<ContaAnoMesSaldoRespostaDTO> Handle(ContaAnoMesSaldoAdicionarCommand request, CancellationToken cancellationToken)
    {
        var entity = EuGastei.Domain.Entities.ContaAnoMesSaldo.Criar(
            request.Dto.TenantId, 
            request.Dto.ContaId, 
            request.Dto.AnoId, 
            request.Dto.MesId);
            
        await _contaAnoMesSaldoRepository.AdicionarAsync(entity, cancellationToken);
        await _contaAnoMesSaldoRepository.SaveChangesAsync();
        return _mapper.Map<ContaAnoMesSaldoRespostaDTO>(entity);
    }

    public async Task<ContaAnoMesSaldoRespostaDTO> Handle(ContaAnoMesSaldoAtualizarCommand request, CancellationToken cancellationToken)
    {
        var entity = await _contaAnoMesSaldoRepository.ObterPorIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new Exception("Saldo não encontrado");

        entity.AtualizarValores(request.Dto.Receitas, request.Dto.Despesas);

        await _contaAnoMesSaldoRepository.SaveChangesAsync();
        return _mapper.Map<ContaAnoMesSaldoRespostaDTO>(entity);
    }

    public async Task<bool> Handle(ContaAnoMesSaldoRemoverCommand request, CancellationToken cancellationToken)
    {
        var entity = await _contaAnoMesSaldoRepository.ObterPorIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new Exception("Saldo não encontrado");

        await _contaAnoMesSaldoRepository.RemoverAsync(entity, cancellationToken);
        await _contaAnoMesSaldoRepository.SaveChangesAsync();
        return true;
    }
}
