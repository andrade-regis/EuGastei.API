namespace EuGastei.Domain.QueryObject;

public class PermissaoFiltro
{
    public Guid? TenantId { get; set; }
    public string? Sigla { get; set; }
    public bool? Ativo { get; set; }
}