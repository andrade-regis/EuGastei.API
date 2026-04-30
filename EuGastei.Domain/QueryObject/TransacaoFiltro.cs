using EuGastei.Domain.Enums;

namespace EuGastei.Domain.QueryObject;

public class TransacaoFiltro
{
    public Guid? TenantId { get; set; }
    public Guid? CategoriaId { get; set; }
    public Guid? FormaDePagamentoId { get; set; }
    public Guid? ContaId { get; set; }
    public Guid? AnoId { get; set; }
    public Guid? MesId { get; set; }
    public EStatusTransacao? Status { get; set; }
}