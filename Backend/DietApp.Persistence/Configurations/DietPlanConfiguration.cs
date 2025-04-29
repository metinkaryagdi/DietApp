using DietApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietApp.Persistence.Configurations
{
    public class DietPlanConfiguration : IEntityTypeConfiguration<DietPlan>
    {
        public void Configure(EntityTypeBuilder<DietPlan> builder)
        {
            builder.HasKey(dp => dp.Id);

            builder.Property(dp => dp.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(dp => dp.TotalCalories)
                .HasPrecision(8, 2);

            builder.Property(dp => dp.TotalProtein)
                .HasPrecision(8, 2);

            builder.Property(dp => dp.TotalCarbohydrate)
                .HasPrecision(8, 2);

            builder.Property(dp => dp.TotalFat)
                .HasPrecision(8, 2);

            // Cascade delete for related entities
            builder.HasMany(dp => dp.Meals)
                .WithOne(m => m.DietPlan)
                .HasForeignKey(m => m.DietPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship with User
            builder.HasOne(dp => dp.User)
                .WithMany()
                .HasForeignKey(dp => dp.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
