using AutoMapper;
using EuGastei.Application.DTOs.Categoria;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Categoria.Consultar.Handler;

public class CategoriaConsultarQueryHandler : IRequestHandler<CategoriaConsultarQuery, IEnumerable<CategoriaRespostaDTO>>
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IMapper _mapper;

    public CategoriaConsultarQueryHandler(ICategoriaRepository categoryRepository, IMapper mapper)
    {
        _categoriaRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoriaRespostaDTO>> Handle(CategoriaConsultarQuery request, CancellationToken cancellationToken)
    {
        var categorias = await _categoriaRepository.ListarAsync(c =>
            (!request.Filtro.TenantId.HasValue || c.TenantId == request.Filtro.TenantId.Value) &&
            (!request.Filtro.TipoDeTransacaoId.HasValue || c.TipoDeTransacaoId == request.Filtro.TipoDeTransacaoId.Value) &&
            (!request.Filtro.CategoriaPaiId.HasValue || c.CategoriaPaiId == request.Filtro.CategoriaPaiId.Value) &&
            (string.IsNullOrEmpty(request.Filtro.Nome) || c.Nome.Contains(request.Filtro.Nome)) &&
            (!request.Filtro.Ativo.HasValue || c.Ativo == request.Filtro.Ativo.Value),
            cancellationToken);

        return _mapper.Map<IEnumerable<CategoriaRespostaDTO>>(categorias);
    }
}
