using AutoMapper;
using EuGastei.Application.DTOs.Conta;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Conta.Handler;

public class ContaHandler : IRequestHandler<ContaAdicionarCommand, ContaRespostaDTO>,
                            IRequestHandler<ContaAtualizarCommand, ContaRespostaDTO>,
                            IRequestHandler<ContaRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IContaRepository _contaRepository;

    public ContaHandler(IMapper mapper, IContaRepository contaRepository)
    {
        _mapper = mapper;
        _contaRepository = contaRepository;
    }

    public async Task<ContaRespostaDTO> Handle(ContaAdicionarCommand request, CancellationToken cancellationToken)
    {
        var conta = EuGastei.Domain.Entities.Conta.Criar(request.Dto.TenantId, request.Dto.Nome);
        await _contaRepository.AdicionarAsync(conta);
        await _contaRepository.SaveChangesAsync();
        return _mapper.Map<ContaRespostaDTO>(conta);
    }

    public async Task<ContaRespostaDTO> Handle(ContaAtualizarCommand request, CancellationToken cancellationToken)
    {
        var conta = await _contaRepository.ObterPorIdAsync(request.Dto.Id);
        if (conta == null) throw new Exception("Conta não encontrada");

        conta.AtualizarNome(request.Dto.Nome);
        
        if (request.Dto.Ativo) conta.Ativar();
        else conta.Desativar();

        await _contaRepository.SaveChangesAsync();
        return _mapper.Map<ContaRespostaDTO>(conta);
    }

    public async Task<bool> Handle(ContaRemoverCommand request, CancellationToken cancellationToken)
    {
        var conta = await _contaRepository.ObterPorIdAsync(request.Id);
        if (conta == null) throw new Exception("Conta não encontrada");

        await _contaRepository.RemoverAsync(conta);
        await _contaRepository.SaveChangesAsync();
        return true;
    }
}
