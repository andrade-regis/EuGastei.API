using EuGastei.Domain.Enums;

namespace EuGastei.Domain.QueryObject;

public class TransacaoRecorrenteFiltro
{
    public Guid? TenantId { get; set; }
    public Guid? CategoriaId { get; set; }
    public Guid? FormaDePagamentoId { get; set; }
    public Guid? ContaId { get; set; }
    public Guid? MesInicioId { get; set; }
    public Guid? AnoInicioId { get; set; }
    public EFrequenciaTransacao? Frequencia { get; set; }
    public bool? Ativo { get; set; }
}