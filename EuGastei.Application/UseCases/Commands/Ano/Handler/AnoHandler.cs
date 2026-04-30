using AutoMapper;
using EuGastei.Application.DTOs.Ano;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Ano.Handler;

public class AnoHandler : IRequestHandler<AnoAdicionarCommand, AnoRespostaDTO>,
                          IRequestHandler<AnoAtualizarCommand, AnoRespostaDTO>,
                          IRequestHandler<AnoRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IAnoRepository _anoRepository;

    public AnoHandler(IMapper mapper, IAnoRepository anoRepository)
    {
        _mapper = mapper;
        _anoRepository = anoRepository;
    }

    public async Task<AnoRespostaDTO> Handle(AnoAdicionarCommand request, CancellationToken cancellationToken)
    {
        var ano = Ano.Criar(request.TenantId, request.Numero);
        await _anoRepository.AdicionarAsync(ano);
        await _anoRepository.SaveChangesAsync();
        return _mapper.Map<AnoRespostaDTO>(ano);
    }

    public async Task<AnoRespostaDTO> Handle(AnoAtualizarCommand request, CancellationToken cancellationToken)
    {
        var ano = await _anoRepository.ObterPorIdAsync(request.Id);
        if (ano == null) throw new Exception("Ano não encontrado");

        ano.AtualizarNumero(request.Numero);
        await _anoRepository.SaveChangesAsync();
        return _mapper.Map<AnoRespostaDTO>(ano);
    }

    public async Task<bool> Handle(AnoRemoverCommand request, CancellationToken cancellationToken)
    {
        var ano = await _anoRepository.ObterPorIdAsync(request.Id);
        if (ano == null) throw new Exception("Ano não encontrado");

        await _anoRepository.RemoverAsync(ano);
        await _anoRepository.SaveChangesAsync();
        return true;
    }
}
