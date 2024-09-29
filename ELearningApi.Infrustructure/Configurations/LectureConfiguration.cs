using ELearningApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
{
       public void Configure(EntityTypeBuilder<Lecture> builder)
       {
              builder.HasKey(l => l.Id);
              builder.Property(l => l.Id).ValueGeneratedOnAdd();
              builder.Property(l => l.Title).IsRequired().HasMaxLength(255);
              builder.Property(l => l.Description).HasMaxLength(1000);
              builder.Property(l => l.Content).HasMaxLength(10000);
              builder.Property(l => l.Duration).HasColumnType("time");
              builder.Property(l => l.OrderIndex).IsRequired();
              builder.Property(l => l.Type).IsRequired();
              builder.Property(l => l.VideoUrl).HasMaxLength(500);
              builder.HasOne(l => l.Section)
                     .WithMany(s => s.Lectures)
                     .HasForeignKey(l => l.SectionId)
                     .OnDelete(DeleteBehavior.Cascade);
              builder.HasMany(l => l.Progresses)
                     .WithOne(p => p.Lecture)
                     .HasForeignKey(p => p.LectureId)
                     .OnDelete(DeleteBehavior.Cascade);
              builder.HasMany(l => l.Resources)
                     .WithOne(r => r.Lecture)
                     .HasForeignKey(r => r.LectureId)
                     .OnDelete(DeleteBehavior.Cascade);
             
       }
}