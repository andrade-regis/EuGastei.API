namespace EuGastei.Domain.QueryObject;

public class CategoriaFiltro
{
    public Guid? TenantId { get; set; }
    public Guid? TipoDeTransacaoId { get; set; }
    public Guid? CategoriaPaiId { get; set; }
    public string? Nome { get; set; }
    public bool? Ativo { get; set; }
}