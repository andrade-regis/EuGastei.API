namespace EuGastei.Application.UseCases.Commands.Usuario;

public class UsuarioAtualizarCommand
{
    public Guid Id { get; set; }
    public Guid? PerfilId { get; set; }
    public string? Nome { get; set; }
    public string? Apelido { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
}