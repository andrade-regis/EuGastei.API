using AutoMapper;
using EuGastei.Application.DTOs.Usuario;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;
using System.Net;

namespace EuGastei.Application.UseCases.Commands.Usuario.Atualizar;

public class UsuarioAtualizarCommandHandler : IRequestHandler<UsuarioAtualizarCommand, UsuarioRespostaDTO>
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioAtualizarCommandHandler(IMapper mapper, 
                                          IUsuarioRepository usuarioRepository)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioRespostaDTO> Handle(UsuarioAtualizarCommand data, 
                                           CancellationToken cancellationToken)
    {
       var usuario = await _usuarioRepository.ObterPorIdAsync(data.Id);

        if(data.PerfilId.HasValue)
            usuario.AtualizarPerfilId(data.PerfilId.Value);

        if(!string.IsNullOrEmpty(data.Nome)) 
            usuario.AtualizarNome(data.Nome);

        if(!string.IsNullOrEmpty(data.Apelido))
            usuario.AtualizarApelido(data.Apelido);

        if(!string.IsNullOrEmpty(data.Email))
            usuario.AtualizarEmail(data.Email);

        if(!string.IsNullOrEmpty(data.Senha))
            usuario.AtualizarSenha(data.Senha);

        _usuarioRepository.Atualizar(usuario);

        await _usuarioRepository.SaveChangesAsync();

        return _mapper.Map<UsuarioRespostaDTO>(usuario);
    }
}