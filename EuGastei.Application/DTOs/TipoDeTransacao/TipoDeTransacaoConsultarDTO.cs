namespace EuGastei.Application.DTOs.TipoDeTransacao
{
    public class TipoDeTransacaoConsultarDTO
    {
        public Guid? TenantId { get; set; }
        public string? Nome { get; set; }
        public bool? Ativo { get; set; }
    }
}
