using EuGastei.Application.Mappings;

namespace EuGastei.Presentation.DependencyInjection
{
    public static class MappersDependencyInjection
    {
        public static void RegistrarMappers(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<UsuarioMapping>());
        }
    }
}
