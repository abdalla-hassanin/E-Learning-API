using ELearningApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<Data.Entities.ApplicationUser>
{
    public void Configure(EntityTypeBuilder<Data.Entities.ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(50);
        builder.Property(u => u.LastName).HasMaxLength(50);
        builder.Property(u => u.CreatedAt).HasColumnType("datetime2").IsRequired();
        builder.Property(u => u.UpdatedAt).HasColumnType("datetime2").IsRequired();
        builder.Property(u => u.RefreshToken).HasMaxLength(255).IsRequired(false);
    }
}