using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.Ano
{
    public class AnoAdicionarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar TenantId!")]
        public Guid TenantId { get; set; }
        
        [Required(ErrorMessage = "Obrigatório informar NUMERO!")]
        public int Numero { get; set; }
    }

    public class AnoAtualizarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar ID!")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Obrigatório informar NUMERO!")]
        public int Numero { get; set; }
    }

    public class AnoConsultarDTO
    {
        public Guid? TenantId { get; set; }
        public int? Numero { get; set; }
    }

    public class AnoRemoverDTO
    {
        public Guid Id { get; set; }
    }

    public class AnoRespostaDTO
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public int Numero { get; set; }
    }
}
