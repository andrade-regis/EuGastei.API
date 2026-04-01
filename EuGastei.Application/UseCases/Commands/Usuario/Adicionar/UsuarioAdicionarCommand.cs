using EuGastei.Application.DTOs.Usuario;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Usuario.Adicionar;

public record UsuarioAdicionarCommand (string? Nome, 
                                       string? Apelido, 
                                       string? Email,
                                       string? Senha) : IRequest<UsuarioRespostaDTO>;