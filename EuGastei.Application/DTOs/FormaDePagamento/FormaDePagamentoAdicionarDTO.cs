using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.FormaDePagamento
{
    public class FormaDePagamentoAdicionarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar TenantId!")]
        public Guid TenantId { get; set; }
        
        [Required(ErrorMessage = "Obrigatório informar NOME!")]
        public string Nome { get; set; }
    }
}
