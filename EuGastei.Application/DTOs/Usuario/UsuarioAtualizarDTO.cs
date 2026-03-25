using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.Usuario
{
    //TODO: 1 - TERMINAR DTOs
    public class UsuarioAtualizarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar ID!")]
        public Guid Id { get; set; }
        public Guid? PerfilId { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
