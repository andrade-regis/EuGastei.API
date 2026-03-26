namespace EuGastei.Application.UseCases.Commands.Usuario;

public class UsuarioAdicionarCommand
{
    //TODO: 1. IMPLEMENTAR VALIDATION PARA ESSE COMMAND
    public string Nome { get; set; }
    public string? Apelido { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}