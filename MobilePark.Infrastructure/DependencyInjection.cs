using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MobilePark.Application.Interfaces;
using MobilePark.Infrastructure.Models.Configs;
using MobilePark.Infrastructure.Services;

namespace MobilePark.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IDbContext>(provider
               => provider.GetService<ApplicationDbContext>());

            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<ICountService, CountService>();
            services.AddScoped<IDbNewsLogger, DbNewsLogger>();
            services.AddSingleton(RegisterConfig<NewsApiConfig>(configuration));

            return services;
        }

        private static T RegisterConfig<T>(IConfiguration configuration)
            where T : new()
        {
            var settings = new T();

            configuration.GetSection(typeof(T).Name)
                .GetChildren()
                .ToList()
                .ForEach(p =>
                {
                    var property = settings.GetType().GetProperty(p.Key);

                    if (property is not null)
                    {
                        var value = Convert.ChangeType(p.Value, property.PropertyType);
                        property.SetValue(settings, value);
                    }
                });

            return settings;
        }
    }
}