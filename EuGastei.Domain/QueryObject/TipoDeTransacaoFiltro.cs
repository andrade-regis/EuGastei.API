namespace EuGastei.Domain.QueryObject;

public class TipoDeTransacaoFiltro
{
    public Guid? TenantId { get; set; }
    public string? Nome { get; set; }
    public bool? Ativo { get; set; }
}