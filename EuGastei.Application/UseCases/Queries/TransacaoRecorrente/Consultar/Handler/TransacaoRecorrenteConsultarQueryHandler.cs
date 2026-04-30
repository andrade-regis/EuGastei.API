using AutoMapper;
using EuGastei.Application.DTOs.TransacaoRecorrente;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.TransacaoRecorrente.Consultar.Handler;

public class TransacaoRecorrenteConsultarQueryHandler : IRequestHandler<TransacaoRecorrenteConsultarQuery, IEnumerable<TransacaoRecorrenteRespostaDTO>>
{
    private readonly ITransacaoRecorrenteRepository _repository;
    private readonly IMapper _mapper;

    public TransacaoRecorrenteConsultarQueryHandler(ITransacaoRecorrenteRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TransacaoRecorrenteRespostaDTO>> Handle(TransacaoRecorrenteConsultarQuery request, CancellationToken cancellationToken)
    {
        var results = await _repository.ListarAsync(c =>
            (!request.Filtro.TenantId.HasValue || c.TenantId == request.Filtro.TenantId.Value) &&
            (!request.Filtro.CategoriaId.HasValue || c.CategoriaId == request.Filtro.CategoriaId.Value) &&
            (!request.Filtro.ContaId.HasValue || c.ContaId == request.Filtro.ContaId.Value) &&
            (!request.Filtro.Ativo.HasValue || c.Ativo == request.Filtro.Ativo.Value),
            cancellationToken);

        return _mapper.Map<IEnumerable<TransacaoRecorrenteRespostaDTO>>(results);
    }
}
