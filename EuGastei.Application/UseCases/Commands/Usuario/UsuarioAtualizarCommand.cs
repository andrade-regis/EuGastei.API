using EuGastei.Application.DTOs.Usuario;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Usuario;

public record UsuarioAtualizarCommand(Guid Id, 
                                      Guid? PerfilId,
                                      string? Nome,
                                      string? Apelido,
                                      string? Email,
                                      string? Senha) : IRequest<UsuarioRespostaResponse>;
