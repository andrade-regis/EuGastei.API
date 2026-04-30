using AutoMapper;
using EuGastei.Application.DTOs.Mes;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Mes.Handler;

public class MesHandler : IRequestHandler<MesAdicionarCommand, MesRespostaDTO>,
                          IRequestHandler<MesAtualizarCommand, MesRespostaDTO>,
                          IRequestHandler<MesRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IMesRepository _mesRepository;

    public MesHandler(IMapper mapper, IMesRepository mesRepository)
    {
        _mapper = mapper;
        _mesRepository = mesRepository;
    }

    public async Task<MesRespostaDTO> Handle(MesAdicionarCommand request, CancellationToken cancellationToken)
    {
        var mes = Mes.Criar(request.TenantId, request.Numero);
        await _mesRepository.AdicionarAsync(mes);
        await _mesRepository.SaveChangesAsync();
        return _mapper.Map<MesRespostaDTO>(mes);
    }

    public async Task<MesRespostaDTO> Handle(MesAtualizarCommand request, CancellationToken cancellationToken)
    {
        var mes = await _mesRepository.ObterPorIdAsync(request.Id);
        if (mes == null) throw new Exception("Mes não encontrado");

        mes.AtualizarNumero(request.Numero);
        await _mesRepository.SaveChangesAsync();
        return _mapper.Map<MesRespostaDTO>(mes);
    }

    public async Task<bool> Handle(MesRemoverCommand request, CancellationToken cancellationToken)
    {
        var mes = await _mesRepository.ObterPorIdAsync(request.Id);
        if (mes == null) throw new Exception("Mes não encontrado");

        await _mesRepository.RemoverAsync(mes);
        await _mesRepository.SaveChangesAsync();
        return true;
    }
}
