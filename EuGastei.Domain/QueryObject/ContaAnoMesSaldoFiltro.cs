namespace EuGastei.Domain.QueryObject;

public class ContaAnoMesSaldoFiltro
{
    public Guid? TenantId { get; set; }
    public Guid? ContaId { get; set; }
    public Guid? AnoId { get; set; }
    public Guid? MesId { get; set; }
}