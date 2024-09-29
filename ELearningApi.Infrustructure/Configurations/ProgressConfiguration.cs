using ELearningApi.Data.Entities;
using ELearningApi.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class ProgressConfiguration : IEntityTypeConfiguration<Progress>
{
    public void Configure(EntityTypeBuilder<Progress> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.StartedAt).HasColumnType("datetime2");
        builder.Property(p => p.CompletedAt).HasColumnType("datetime2");
        builder.Property(p => p.Status).IsRequired();
        builder.Property(p => p.ProgressPercentage).HasColumnType("decimal(5,2)");
        builder.HasOne(p => p.Enrollment)
            .WithMany(e => e.Progresses)
            .HasForeignKey(p => p.EnrollmentId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(p => p.Lecture)
            .WithMany(l => l.Progresses)
            .HasForeignKey(p => p.LectureId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}