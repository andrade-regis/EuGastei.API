using EuGastei.Presentation.DependencyInjection;

namespace EuGastei.Presentation.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void Registrar(WebApplicationBuilder builder)
        {
            ServicesDependencyInjection.RegistrarServices(builder);
            RepositoriesDependencyInjection.RegistrarRepositories(builder);
            MappersDependencyInjection.RegistrarMappers(builder);
        }
    }
}
