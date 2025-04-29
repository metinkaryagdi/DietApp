using DietApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietApp.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Height)
                .IsRequired()
                .HasPrecision(5, 2);

            builder.Property(u => u.Weight)
                .IsRequired()
                .HasPrecision(5, 2);

            builder.Property(u => u.TargetWeight)
                .IsRequired()
                .HasPrecision(5, 2);

            // Cascade delete for related entities
            builder.HasMany(u => u.Meals)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.DailyNutritions)
                .WithOne(dn => dn.User)
                .HasForeignKey(dn => dn.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 