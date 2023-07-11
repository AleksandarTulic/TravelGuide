using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Travel.API.Contracts;
using Travel.API.Entities.Context;
using Travel.API.Repositories;

namespace Travel.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TravelPlannerDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Db"));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDestinationRepository, DestinationRepository>();

            return services;
        }
    }
}
