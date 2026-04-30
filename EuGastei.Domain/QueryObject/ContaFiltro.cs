namespace EuGastei.Domain.QueryObject;

public class ContaFiltro
{
    public Guid? TenantId { get; set; }
    public string? Nome { get; set; }
    public bool? Ativo { get; set; }
}