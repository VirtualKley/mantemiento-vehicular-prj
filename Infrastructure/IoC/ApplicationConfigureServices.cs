using Application.Interfaces;
using Application.Servicios;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public static class ApplicationConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMantenimientoVehicularService, MantenimientoVehicularService>();
            return services;
        }
    }
}
