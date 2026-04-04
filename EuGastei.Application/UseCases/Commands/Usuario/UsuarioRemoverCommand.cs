using MediatR;

namespace EuGastei.Application.UseCases.Commands.Usuario;

public record UsuarioRemoverCommand(Guid Id) : IRequest<bool>;