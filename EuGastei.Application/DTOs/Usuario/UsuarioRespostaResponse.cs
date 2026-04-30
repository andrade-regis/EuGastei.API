namespace EuGastei.Application.DTOs.Usuario
{
    public class UsuarioRespostaResponse
    {
        public Guid Id { get; set; }
        public string? Perfil  { get; set; }
        public string Nome { get; set; }
        public string? Apelido { get; set; }
        public string Email { get; set; }
    }
}
