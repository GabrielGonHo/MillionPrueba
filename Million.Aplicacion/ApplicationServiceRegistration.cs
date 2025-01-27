using Microsoft.Extensions.DependencyInjection;

using Million.Aplicacion.Servicios;
using Million.Dominio.Interfaces;
using Million.Persistencia;

namespace Million.Aplicacion
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
        {
            // Registrar servicios de la capa de persistencia
            services.AddPersistenceServices(connectionString);

            // Registrar servicios en la capa de aplicación
            services.AddScoped<PropertyService>();

            return services;
        }
    }
}

