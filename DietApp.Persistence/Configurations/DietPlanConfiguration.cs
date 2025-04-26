using DietApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietApp.Persistence.Configurations
{
    public class DietPlanConfiguration : IEntityTypeConfiguration<DietPlan>
    {
        public void Configure(EntityTypeBuilder<DietPlan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Meals).IsRequired().HasMaxLength(500);
            builder.Property(x => x.TotalCalories).IsRequired(false);
            builder.Property(x => x.TotalProtein).IsRequired(false);
            builder.Property(x => x.TotalCarbohydrate).IsRequired(false);
            builder.Property(x => x.TotalFat).IsRequired(false);
        }
    }
}
