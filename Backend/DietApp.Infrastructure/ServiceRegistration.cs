using DietApp.Domain.Interfaces;
using DietApp.Domain.Services;
using DietApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DietApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<INutritionCalculatorService, NutritionCalculatorService>();
        }
    }
} 