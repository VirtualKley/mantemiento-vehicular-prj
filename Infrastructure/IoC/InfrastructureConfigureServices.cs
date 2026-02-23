using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public static class InfrastructureConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IMantenimientoVehicularRepository, MantenimientoVehicularRepository>();
            return services;
        }
    }
}
