using DietApp.Application.Abstractions.Services;
using DietApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DietApp.WebAPI.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IMealAnalyzerService, MealAnalyzerService>();
        }
    }
}
