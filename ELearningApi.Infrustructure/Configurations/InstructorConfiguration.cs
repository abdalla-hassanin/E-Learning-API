using ELearningApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Data.Entities.Instructor>
{
    public void Configure(EntityTypeBuilder<Data.Entities.Instructor> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();
            
        builder.HasOne(i => i.ApplicationUser)
            .WithOne()
            .HasForeignKey<Instructor>(i => i.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(i => i.Expertise).HasMaxLength(100);
        builder.Property(i => i.Biography).HasMaxLength(1000);

        builder.HasMany(i => i.Courses)
            .WithOne(c => c.Instructor)
            .HasForeignKey(c => c.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
