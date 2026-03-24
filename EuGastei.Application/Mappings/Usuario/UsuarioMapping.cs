using AutoMapper;
using EuGastei.Application.DTOs.Usuario;
using EuGastei.Domain.Entities;

namespace EuGastei.Application.Mappings;

public class UsuarioMapping : Profile
{
    public UsuarioMapping()
    {
        CreateMap<Usuario, UsuarioDTO>();
    }
}