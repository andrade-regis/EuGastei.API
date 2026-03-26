using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.Usuario
{
    public class UsuarioAtualizarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar Id!")]
        public Guid Id { get; set; }
        public Guid? PerfilId { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
