using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.Mes
{
    public class MesAdicionarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar TenantId!")]
        public Guid TenantId { get; set; }
        
        [Required(ErrorMessage = "Obrigatório informar NUMERO!")]
        public int Numero { get; set; }
    }
}
