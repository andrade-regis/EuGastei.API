using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.Usuario
{
    public class UsuarioAdicionarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar NOME!")]
        public string Nome { get; set; }
        public string? Apelido { get; set; }

        [Required(ErrorMessage = "Obrigatório informar EMAIL")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar SENHA")]
        public string Senha { get; set; }
    }
}
