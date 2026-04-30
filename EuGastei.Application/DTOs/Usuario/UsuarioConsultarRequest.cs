namespace EuGastei.Application.DTOs.Usuario
{
    public class UsuarioConsultarRequest
    {
        public Guid? PerfilId  { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public string? Email { get; set; }
    }
}
