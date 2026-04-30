using AutoMapper;
using EuGastei.Application.DTOs.TipoDeTransacao;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.TipoDeTransacao.Consultar.Handler;

public class TipoDeTransacaoConsultarQueryHandler : IRequestHandler<TipoDeTransacaoConsultarQuery, IEnumerable<TipoDeTransacaoRespostaDTO>>
{
    private readonly ITipoDeTransacaoRepository _tipoDeTransacaoRepository;
    private readonly IMapper _mapper;

    public TipoDeTransacaoConsultarQueryHandler(ITipoDeTransacaoRepository tipoDeTransacaoRepository, IMapper mapper)
    {
        _tipoDeTransacaoRepository = tipoDeTransacaoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TipoDeTransacaoRespostaDTO>> Handle(TipoDeTransacaoConsultarQuery request, CancellationToken cancellationToken)
    {
        var tiposDeTransacao = await _tipoDeTransacaoRepository.ListarAsync(x =>
            (!request.Filtro.TenantId.HasValue || x.TenantId == request.Filtro.TenantId.Value) &&
            (string.IsNullOrEmpty(request.Filtro.Nome) || x.Nome.Contains(request.Filtro.Nome)) &&
            (!request.Filtro.Ativo.HasValue || x.Ativo == request.Filtro.Ativo.Value));

        return _mapper.Map<IEnumerable<TipoDeTransacaoRespostaDTO>>(tiposDeTransacao);
    }
}
