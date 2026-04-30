using AutoMapper;
using EuGastei.Application.DTOs.Transacao;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Transacao.Consultar.Handler;

public class TransacaoConsultarHandler : IRequestHandler<TransacaoConsultarQuery, IEnumerable<TransacaoRespostaDTO>>
{
    private readonly IMapper _mapper;
    private readonly ITransacaoRepository _transacaoRepository;

    public TransacaoConsultarHandler(IMapper mapper, ITransacaoRepository transacaoRepository)
    {
        _mapper = mapper;
        _transacaoRepository = transacaoRepository;
    }

    public async Task<IEnumerable<TransacaoRespostaDTO>> Handle(TransacaoConsultarQuery request, CancellationToken cancellationToken)
    {
        var transacoes = await _transacaoRepository.ListarAsync(x =>
            (!request.TenantId.HasValue || x.TenantId == request.TenantId) &&
            (!request.CategoriaId.HasValue || x.CategoriaId == request.CategoriaId) &&
            (!request.FormaDePagamentoId.HasValue || x.FormaDePagamentoId == request.FormaDePagamentoId) &&
            (!request.ContaId.HasValue || x.ContaId == request.ContaId) &&
            (!request.AnoId.HasValue || x.AnoId == request.AnoId) &&
            (!request.MesId.HasValue || x.MesId == request.MesId) &&
            (!request.Status.HasValue || x.Status == request.Status),
            cancellationToken);

        return _mapper.Map<IEnumerable<TransacaoRespostaDTO>>(transacoes);
    }
}
