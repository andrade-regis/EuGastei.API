namespace EuGastei.Domain.QueryObject;

public class PerfilPermissaoFiltro
{
    public Guid? TenantId { get; set; }
    public Guid? PerfilId { get; set; }
    public Guid? PermissaoId { get; set; }
}