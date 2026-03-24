using EuGastei.Application.DTOs.Usuario;

namespace EuGastei.Application.Services;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> GetAllAsync();
    Task<UsuarioDTO> GetByIdAsync(Guid id);
    Task AddAsync(UsuarioDTO usuarioDTO);
    Task UpdateAsync(UsuarioDTO usuarioDTO);
    Task DeleteAsync(Guid id);
}