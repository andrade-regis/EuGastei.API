using EuGastei.Application.DTOs.Categoria;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Categoria.Consultar;

public record CategoriaConsultarQuery(CategoriaConsultarDTO Filtro) : IRequest<IEnumerable<CategoriaRespostaDTO>>;
