using DietApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietApp.Persistence.Configurations
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(500);

            builder.Property(m => m.TotalCalories)
                .HasPrecision(8, 2);

            builder.Property(m => m.TotalProtein)
                .HasPrecision(8, 2);

            builder.Property(m => m.TotalCarbohydrate)
                .HasPrecision(8, 2);

            builder.Property(m => m.TotalFat)
                .HasPrecision(8, 2);

            // Relationship with MealFood
            builder.HasMany(m => m.MealFoods)
                .WithOne(mf => mf.Meal)
                .HasForeignKey(mf => mf.MealId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship with User
            builder.HasOne(m => m.User)
                .WithMany(u => u.Meals)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship with DietPlan
            builder.HasOne(m => m.DietPlan)
                .WithMany(dp => dp.Meals)
                .HasForeignKey(m => m.DietPlanId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 