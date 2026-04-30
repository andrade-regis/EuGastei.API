using EuGastei.Application.DTOs.Categoria;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Categoria;

public record CategoriaAdicionarCommand(CategoriaAdicionarDTO Dto) : IRequest<CategoriaRespostaDTO>;
public record CategoriaAtualizarCommand(CategoriaAtualizarDTO Dto) : IRequest<CategoriaRespostaDTO>;
public record CategoriaRemoverCommand(Guid Id) : IRequest<bool>;
