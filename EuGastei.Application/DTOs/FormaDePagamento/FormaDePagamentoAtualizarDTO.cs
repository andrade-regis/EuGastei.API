using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.FormaDePagamento
{
    public class FormaDePagamentoAtualizarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar ID!")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Obrigatório informar NOME!")]
        public string Nome { get; set; }
    }
}
