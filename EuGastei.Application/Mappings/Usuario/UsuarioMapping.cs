using AutoMapper;
using EuGastei.Application.DTOs.Usuario;
using EuGastei.Application.UseCases.Commands.Usuario;
using EuGastei.Application.UseCases.Queries.Usuario.Consultar;
using EuGastei.Domain.Entities;
using EuGastei.Domain.QueryObject;

namespace EuGastei.Application.Mappings;

public class UsuarioMapping : Profile
{
    public UsuarioMapping()
    {
        CreateMap<Usuario, UsuarioRespostaResponse>().ReverseMap();
        CreateMap<UsuarioAdicionarRequest, UsuarioAdicionarCommand>().ReverseMap();
        CreateMap<UsuarioAtualizarRequest, UsuarioAtualizarCommand>().ReverseMap();
        CreateMap<UsuarioRemoverRequest, UsuarioRemoverCommand>().ReverseMap();
        CreateMap<UsuarioConsultarRequest, UsuarioConsultarQuery>().ReverseMap();
        CreateMap<UsuarioFiltro, UsuarioConsultarQuery>().ReverseMap();
    }
}