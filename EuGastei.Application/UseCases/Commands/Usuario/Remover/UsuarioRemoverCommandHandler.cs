using EuGastei.Domain.Interfaces.Repositories;
using MediatR;
using System.Reflection.Metadata;

namespace EuGastei.Application.UseCases.Commands.Usuario.Remover;

public class UsuarioRemoverCommandHandler : IRequestHandler<UsuarioRemoverCommand, bool>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioRemoverCommandHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<bool> Handle(UsuarioRemoverCommand data, 
                                   CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(data.Id);

        usuario.AtualizarAtivo(false);

        _usuarioRepository.Atualizar(usuario);

        await _usuarioRepository.SaveChangesAsync();

        return true;
    }
}