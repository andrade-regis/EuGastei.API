using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.Tenant
{
    public class TenantAdicionarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar NOME!")]
        public string Nome { get; set; }
    }
}
