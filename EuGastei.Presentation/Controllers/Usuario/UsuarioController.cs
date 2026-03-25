using EuGastei.Application.DTOs.Usuario;
using EuGastei.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EuGastei.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    //TODO: 2 - Implementar DTO from Body + Mapping(DTO -> Command) -> MediaR = AQUI
    //TODO: 3 - Implementar Command -> Validation -> Handler = NA APLICATION

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioService.GetAllAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
    {
        await _usuarioService.AddAsync(usuarioDTO);
        return CreatedAtAction(nameof(GetById), new { id = usuarioDTO.Id }, usuarioDTO);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UsuarioDTO usuarioDTO)
    {
        if (id != usuarioDTO.Id)
            return BadRequest();

        await _usuarioService.UpdateAsync(usuarioDTO);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _usuarioService.DeleteAsync(id);
        return NoContent();
    }
}