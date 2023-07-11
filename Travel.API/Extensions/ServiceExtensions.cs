using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Travel.API.Entities.Context;

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
    }
}
