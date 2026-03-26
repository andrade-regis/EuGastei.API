using AutoMapper;
using EuGastei.Application.DTOs.Usuario;
using EuGastei.Application.UseCases.Queries.Usuario;
using EuGastei.Application.UseCases.Commands.Usuario;
using EuGastei.Domain.Entities;

namespace EuGastei.Application.Mappings;

public class UsuarioMapping : Profile
{
    public UsuarioMapping()
    {
        CreateMap<Usuario, UsuarioRespostaDTO>().ReverseMap();
        CreateMap<UsuarioAdicionarDTO, UsuarioAdicionarCommand>().ReverseMap();
        CreateMap<UsuarioAtualizarDTO, UsuarioAtualizarCommand>().ReverseMap();
        CreateMap<UsuarioRemoverDTO, UsuarioRemoverCommand>().ReverseMap();
        CreateMap<UsuarioConsultarDTO, UsuarioConsultarQuery>().ReverseMap();
    }
}