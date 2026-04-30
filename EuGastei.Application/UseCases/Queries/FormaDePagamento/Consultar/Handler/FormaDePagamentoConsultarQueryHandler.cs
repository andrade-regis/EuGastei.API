using AutoMapper;
using EuGastei.Application.DTOs.FormaDePagamento;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.FormaDePagamento.Consultar.Handler;

public class FormaDePagamentoConsultarQueryHandler : IRequestHandler<FormaDePagamentoConsultarQuery, IEnumerable<FormaDePagamentoRespostaDTO>>
{
    private readonly IFormaDePagamentoRepository _formaDePagamentoRepository;
    private readonly IMapper _mapper;

    public FormaDePagamentoConsultarQueryHandler(IFormaDePagamentoRepository formaDePagamentoRepository, IMapper mapper)
    {
        _formaDePagamentoRepository = formaDePagamentoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FormaDePagamentoRespostaDTO>> Handle(FormaDePagamentoConsultarQuery request, CancellationToken cancellationToken)
    {
        var formas = await _formaDePagamentoRepository.ListarAsync(x => 
            (!request.TenantId.HasValue || x.TenantId == request.TenantId.Value) &&
            (string.IsNullOrEmpty(request.Nome) || x.Nome.Contains(request.Nome)));
            
        return _mapper.Map<IEnumerable<FormaDePagamentoRespostaDTO>>(formas);
    }
}
