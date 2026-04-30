using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.Mes
{
    public class MesAtualizarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar ID!")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Obrigatório informar NUMERO!")]
        public int Numero { get; set; }
    }
}
