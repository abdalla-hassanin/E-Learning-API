using ELearningApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class LectureResourceConfiguration : IEntityTypeConfiguration<LectureResource>
{
    public void Configure(EntityTypeBuilder<LectureResource> builder)
    {
        builder.HasKey(lr => lr.Id);
        builder.Property(lr => lr.Id).ValueGeneratedOnAdd();
        builder.Property(lr => lr.Title).IsRequired().HasMaxLength(255);
        builder.Property(lr => lr.Description).HasMaxLength(1000);
        builder.Property(lr => lr.Url).IsRequired().HasMaxLength(500);
        builder.Property(lr => lr.Type).IsRequired();
        builder.HasOne(lr => lr.Lecture)
            .WithMany(l => l.Resources)
            .HasForeignKey(lr => lr.LectureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
