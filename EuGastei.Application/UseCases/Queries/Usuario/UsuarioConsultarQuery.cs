namespace EuGastei.Application.UseCases.Queries.Usuario;

public class UsuarioConsultarQuery
{
    //TODO: 2. IMPLEMENTAR VALIDATION PARA ESSE COMMAND
    public Guid? Id { get; set; }
    public string? Perfil  { get; set; }
    public string? Nome { get; set; }
    public string? Apelido { get; set; }
    public string? Email { get; set; }
}