using ELearningApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
       public void Configure(EntityTypeBuilder<Course> builder)
       {
              builder.HasKey(c => c.Id);
              builder.Property(c => c.Id).ValueGeneratedOnAdd();
              builder.Property(c => c.Title).IsRequired().HasMaxLength(255);
              builder.Property(c => c.Description).IsRequired().HasMaxLength(2000);
              builder.Property(c => c.ShortDescription).HasMaxLength(500);
              builder.Property(c => c.Price).HasColumnType("decimal(18,2)");
              builder.Property(c => c.CreatedAt).HasColumnType("datetime2").IsRequired();
              builder.Property(c => c.UpdatedAt).HasColumnType("datetime2").IsRequired();
              builder.Property(c => c.ThumbnailUrl).HasMaxLength(500);
              builder.Property(c => c.TrailerVideoUrl).HasMaxLength(500);
              builder.Property(c => c.Level).IsRequired();
              builder.Property(c => c.EstimatedDuration).HasColumnType("time");
              builder.Property(c => c.PublishedAt).HasColumnType("datetime2");
              
              builder.Property(c => c.Prerequisites).HasConversion(
                     v => string.Join(',', v),
                     v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        
              builder.Property(c => c.LearningObjectives).HasConversion(
                     v => string.Join(',', v),
                     v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

              
              builder.HasOne(c => c.Instructor)
                     .WithMany(i => i.Courses)
                     .HasForeignKey(c => c.InstructorId)
                     .OnDelete(DeleteBehavior.Restrict);
              builder.HasOne(c => c.Category)
                     .WithMany(cat => cat.Courses)
                     .HasForeignKey(c => c.CategoryId)
                     .OnDelete(DeleteBehavior.Restrict);
              builder.HasMany(c => c.Sections)
                     .WithOne(s => s.Course)
                     .HasForeignKey(s => s.CourseId)
                     .OnDelete(DeleteBehavior.Cascade);
              builder.HasMany(c => c.Enrollments)
                     .WithOne(e => e.Course)
                     .HasForeignKey(e => e.CourseId)
                     .OnDelete(DeleteBehavior.Cascade);
              builder.HasMany(c => c.Reviews)
                     .WithOne(r => r.Course)
                     .HasForeignKey(r => r.CourseId)
                     .OnDelete(DeleteBehavior.Cascade);
              
              

        
       }
}