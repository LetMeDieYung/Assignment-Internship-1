using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Events.Application.Interfaces;

namespace Events.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<EventsDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IEventsDbContext>(provider => 
                provider.GetService<EventsDbContext>());
            return services;
        }
    }
}