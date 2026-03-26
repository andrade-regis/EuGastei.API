using System.Reflection;
using EuGastei.Application.Mappings;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Persistance.Repositories;

namespace EuGastei.Presentation.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void RegistrarServices(this IServiceCollection service)
        {
            RegistrarHandlers(service);
            RegistrarMappers(service);
            RegistrarRepositories(service);
        }
        
        private static void  RegistrarHandlers(IServiceCollection services)
        {
            services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
        
        private static void RegistrarMappers(IServiceCollection service)
        {
            service.AddAutoMapper(cfg => cfg.AddProfile<UsuarioMapping>());
        }
        
        private static void RegistrarRepositories(IServiceCollection service)
        {
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
