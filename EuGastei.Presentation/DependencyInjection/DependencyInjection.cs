using System.Reflection;
using EuGastei.Application.Common.Behaviors;
using MediatR;
using FluentValidation;
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
            var assembly = Assembly.GetExecutingAssembly();

            // MediatR
            services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(assembly));

            // FluentValidation
            services.AddValidatorsFromAssembly(assembly);

            // Pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
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
