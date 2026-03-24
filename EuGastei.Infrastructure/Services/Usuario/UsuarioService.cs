using AutoMapper;
using EuGastei.Application.DTOs.Usuario;
using EuGastei.Application.Services;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;

namespace EuGastei.Infrastructure.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
    {
        var usuarios = await _usuarioRepository.ListarAsync();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
    }

    public async Task<UsuarioDTO> GetByIdAsync(Guid id)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(id);
        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task AddAsync(UsuarioDTO usuarioDTO)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDTO);
        await _usuarioRepository.AdicionarAsync(usuario);
        await _usuarioRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(UsuarioDTO usuarioDTO)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDTO);
        await _usuarioRepository.AtualizarAsync(usuario);
        await _usuarioRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(id);
        await _usuarioRepository.RemoverAsync(usuario);
        await _usuarioRepository.SaveChangesAsync();
    }
}