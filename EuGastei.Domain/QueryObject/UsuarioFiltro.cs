namespace EuGastei.Domain.QueryObject;

public class UsuarioFiltro
{
    public Guid? PerfilId { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public bool? Ativo { get; set; }
}