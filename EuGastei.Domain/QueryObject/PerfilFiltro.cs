namespace EuGastei.Domain.QueryObject;

public class PerfilFiltro
{
    public Guid? TenantId { get; set; }
    public string? Nome { get; set; }
    public bool? Ativo { get; set; }
}