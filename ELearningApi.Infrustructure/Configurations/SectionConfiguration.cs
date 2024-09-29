using ELearningApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class SectionConfiguration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();
        builder.Property(s => s.Title).IsRequired().HasMaxLength(255);
        builder.Property(s => s.Description).HasMaxLength(1000);
        builder.Property(s => s.OrderIndex).IsRequired();
        builder.HasOne(s => s.Course)
            .WithMany(c => c.Sections)
            .HasForeignKey(s => s.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(s => s.Lectures)
            .WithOne(l => l.Section)
            .HasForeignKey(l => l.SectionId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(s => s.Quizzes)
            .WithOne(q => q.Section)
            .HasForeignKey(q => q.SectionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}