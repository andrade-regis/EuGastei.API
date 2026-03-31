namespace EuGastei.Application.UseCases.Commands.Usuario.Atualizar;

public record UsuarioAtualizarCommand(Guid Id, 
                                      Guid? PerfilId,
                                      string? Nome,
                                      string? Apelido,
                                      string? Email,
                                      string? Senha);
