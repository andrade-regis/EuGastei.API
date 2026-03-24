using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Persistance.Repositories;

namespace EuGastei.Presentation.DependencyInjection
{
    public static class RepositoriesDependencyInjection
    {
        public static void RegistrarRepositories(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
