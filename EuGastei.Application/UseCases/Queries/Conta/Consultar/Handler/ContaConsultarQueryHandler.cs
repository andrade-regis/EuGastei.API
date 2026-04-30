using AutoMapper;
using EuGastei.Application.DTOs.Conta;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Conta.Consultar.Handler;

public class ContaConsultarQueryHandler : IRequestHandler<ContaConsultarQuery, IEnumerable<ContaRespostaDTO>>
{
    private readonly IContaRepository _contaRepository;
    private readonly IMapper _mapper;

    public ContaConsultarQueryHandler(IContaRepository contaRepository, IMapper mapper)
    {
        _contaRepository = contaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContaRespostaDTO>> Handle(ContaConsultarQuery request, CancellationToken cancellationToken)
    {
        var contas = await _contaRepository.ListarAsync(c =>
            (!request.Filtro.TenantId.HasValue || c.TenantId == request.Filtro.TenantId.Value) &&
            (string.IsNullOrEmpty(request.Filtro.Nome) || c.Nome.Contains(request.Filtro.Nome)) &&
            (!request.Filtro.Ativo.HasValue || c.Ativo == request.Filtro.Ativo.Value),
            cancellationToken);

        return _mapper.Map<IEnumerable<ContaRespostaDTO>>(contas);
    }
}
