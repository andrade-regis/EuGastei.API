using AutoMapper;
using EuGastei.Application.DTOs.Usuario;
using EuGastei.Application.UseCases.Queries.Usuario;
using EuGastei.Application.UseCases.Commands.Usuario;
using EuGastei.Application.UseCases.Queries.Usuario.Consultar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EuGastei.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[EndpointGroupName("usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IMapper _mapper; 
    private readonly IMediator _mediator; 
    
    public UsuarioController(IMapper mapper,
                             IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [HttpGet("/consultar")]
    public async Task<IActionResult> GetAll([FromBody] UsuarioConsultarRequest usuario)
    {
        var command = _mapper.Map<UsuarioConsultarQuery>(usuario);
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPost("/adicionar")]
    public async Task<IActionResult> Post([FromBody] UsuarioAdicionarRequest usuario)
    {
        var command = _mapper.Map<UsuarioAdicionarCommand>(usuario);
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("/atualizar")]
    public async Task<IActionResult> Put([FromBody] UsuarioAtualizarRequest usuario)
    {
        var command = _mapper.Map<UsuarioAtualizarCommand>(usuario);
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("/deletar")]
    public async Task<IActionResult> Delete([FromBody] UsuarioRemoverRequest usuario)
    {
        var command = _mapper.Map<UsuarioRemoverCommand>(usuario);
        return Ok(await _mediator.Send(command));
    }
}