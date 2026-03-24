using EuGastei.Application.Services;
using EuGastei.Infrastructure.Services;

namespace EuGastei.Presentation.DependencyInjection
{
    public static class ServicesDependencyInjection
    {
        public static void RegistrarServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
