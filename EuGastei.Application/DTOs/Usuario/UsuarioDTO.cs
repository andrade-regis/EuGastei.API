using EuGastei.Application.DTOs;

namespace EuGastei.Application.DTOs.Usuario;

public class UsuarioDTO
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
}