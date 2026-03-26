using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.Usuario
{
    public class UsuarioRemoverDTO
    {
        [Required(ErrorMessage = "Obrigatório informar Id!")]
        public Guid Id { get; set; }
    }
}
