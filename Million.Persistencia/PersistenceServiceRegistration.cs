using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Million.Dominio.Interfaces;
using Million.Persistencia.AppDbContext;
using Million.Persistencia.Metodos;

namespace Million.Persistencia
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string connectionString)
        {
            // Configurar DbContext
            services.AddDbContext<AppDbContext.AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Registrar repositorios en la capa de persistencia
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
            services.AddScoped<IPropertyTraceRepository, PropertyTraceRepository>();

            return services;
        }
    }
}

