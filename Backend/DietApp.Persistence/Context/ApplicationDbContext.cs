using DietApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietApp.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<MealFood> MealFoods { get; set; }
        public DbSet<DailyNutrition> DailyNutritions { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User Configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(256);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                
                // Case-insensitive unique indexes
                entity.HasIndex(e => e.Email)
                    .IsUnique()
                    .HasFilter(null)
                    .HasDatabaseName("IX_Users_Email");
                
                entity.HasIndex(e => e.UserName)
                    .IsUnique()
                    .HasFilter(null)
                    .HasDatabaseName("IX_Users_UserName");

                // Navigation properties with cascade delete
                entity.HasMany(e => e.Meals)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.DailyNutritions)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Meal Configuration
            modelBuilder.Entity<Meal>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.HasOne(e => e.User)
                    .WithMany(e => e.Meals)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.DietPlan)
                    .WithMany(e => e.Meals)
                    .HasForeignKey(e => e.DietPlanId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Food Configuration
            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Unit).IsRequired().HasMaxLength(50);
            });

            // MealFood Configuration
            modelBuilder.Entity<MealFood>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Meal)
                    .WithMany(e => e.MealFoods)
                    .HasForeignKey(e => e.MealId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Food)
                    .WithMany(e => e.MealFoods)
                    .HasForeignKey(e => e.FoodId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // DailyNutrition Configuration
            modelBuilder.Entity<DailyNutrition>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                    .WithMany(e => e.DailyNutritions)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // DietPlan Configuration
            modelBuilder.Entity<DietPlan>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });
        }
    }
} 