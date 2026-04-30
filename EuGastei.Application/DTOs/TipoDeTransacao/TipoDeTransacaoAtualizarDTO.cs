using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.TipoDeTransacao
{
    public class TipoDeTransacaoAtualizarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar ID!")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Obrigatório informar NOME!")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
    }
}
