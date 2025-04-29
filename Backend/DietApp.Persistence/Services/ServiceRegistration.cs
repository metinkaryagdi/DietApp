using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DietApp.Persistence.Context;
using DietApp.Domain.Interfaces;
using DietApp.Persistence.Repositories;

namespace DietApp.Persistence.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext kaydı
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repository kayıtları
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
