using DietApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietApp.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DietPlan> DietPlans { get; set; }
    }
}
