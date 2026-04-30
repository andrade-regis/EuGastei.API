namespace EuGastei.Application.DTOs.Tenant
{
    public class TenantRespostaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
