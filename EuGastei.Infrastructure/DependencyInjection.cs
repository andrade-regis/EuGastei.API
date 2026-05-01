using System.Reflection;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Context;
using EuGastei.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EuGastei.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterDBContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<EuGasteiDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
                ));
        }
        
        public static void RegistrarServices(this IServiceCollection service)
        {
            RegistrarHandlers(service);
            RegistrarRepositories(service);
        }
        
        private static void  RegistrarHandlers(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // MediatR
            services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(assembly));
        }
        
        private static void RegistrarRepositories(IServiceCollection service)
        {
            service.AddScoped<ITenantRepository, TenantRepository>();
            service.AddScoped<IAnoRepository, AnoRepository>();
            service.AddScoped<IMesRepository, MesRepository>();
            service.AddScoped<IFormaDePagamentoRepository, FormaDePagamentoRepository>();
            service.AddScoped<ITipoDeTransacaoRepository, TipoDeTransacaoRepository>();
            service.AddScoped<IContaRepository, ContaRepository>();
            service.AddScoped<ICategoriaRepository, CategoriaRepository>();
            service.AddScoped<IContaAnoMesSaldoRepository, ContaAnoMesSaldoRepository>();
            service.AddScoped<ITransacaoRecorrenteRepository, TransacaoRecorrenteRepository>();
            service.AddScoped<ITransacaoRepository, TransacaoRepository>();
            
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
            service.AddScoped<IPerfilRepository, PerfilRepository>();
            service.AddScoped<IPermissaoRepository, PermissaoRepository>();
            service.AddScoped<IPerfilPermissaoRepository, PerfilPermissaoRepository>();
        }
    }
}
