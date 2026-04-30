namespace EuGastei.Application.DTOs.TipoDeTransacao
{
    public class TipoDeTransacaoRespostaDTO
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
