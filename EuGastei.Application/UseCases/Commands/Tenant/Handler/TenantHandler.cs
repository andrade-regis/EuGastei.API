using AutoMapper;
using EuGastei.Application.DTOs.Tenant;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Tenant.Handler;

public class TenantHandler : IRequestHandler<TenantAdicionarCommand, TenantRespostaDTO>,
                             IRequestHandler<TenantAtualizarCommand, TenantRespostaDTO>,
                             IRequestHandler<TenantRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly ITenantRepository _tenantRepository;

    public TenantHandler(IMapper mapper, ITenantRepository tenantRepository)
    {
        _mapper = mapper;
        _tenantRepository = tenantRepository;
    }

    public async Task<TenantRespostaDTO> Handle(TenantAdicionarCommand request, CancellationToken cancellationToken)
    {
        var tenant = Tenant.Criar(request.Nome);
        await _tenantRepository.AdicionarAsync(tenant);
        await _tenantRepository.SaveChangesAsync();
        return _mapper.Map<TenantRespostaDTO>(tenant);
    }

    public async Task<TenantRespostaDTO> Handle(TenantAtualizarCommand request, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.ObterPorIdAsync(request.Id);
        if (tenant == null) throw new Exception("Tenant não encontrado");

        tenant.AtualizarNome(request.Nome);
        if (request.Ativo) tenant.Ativar(); else tenant.Desativar();

        await _tenantRepository.SaveChangesAsync();
        return _mapper.Map<TenantRespostaDTO>(tenant);
    }

    public async Task<bool> Handle(TenantRemoverCommand request, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.ObterPorIdAsync(request.Id);
        if (tenant == null) throw new Exception("Tenant não encontrado");

        await _tenantRepository.RemoverAsync(tenant);
        await _tenantRepository.SaveChangesAsync();
        return true;
    }
}
