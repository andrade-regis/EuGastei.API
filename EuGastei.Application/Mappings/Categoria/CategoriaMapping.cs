using AutoMapper;
using EuGastei.Application.DTOs.Categoria;
using EuGastei.Domain.Entities;

namespace EuGastei.Application.Mappings.Categoria;

public class CategoriaMapping : Profile
{
    public CategoriaMapping()
    {
        CreateMap<EuGastei.Domain.Entities.Categoria, CategoriaRespostaDTO>();
    }
}
