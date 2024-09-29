using ELearningApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasKey(q => q.Id);
        builder.Property(q => q.Id).ValueGeneratedOnAdd();
        builder.Property(q => q.Title).IsRequired().HasMaxLength(255);
        builder.Property(q => q.Description).HasMaxLength(1000);
        builder.Property(q => q.Type).IsRequired();
        builder.Property(q => q.TimeLimit);
        builder.Property(q => q.PassingScore).IsRequired();
        builder.Property(q => q.IsRandomized).IsRequired();
        builder.Property(q => q.ShowCorrectAnswers).IsRequired();
        builder.Property(q => q.MaxAttempts).IsRequired();
        builder.Property(q => q.AvailableFrom).HasColumnType("datetime2").IsRequired();
        builder.Property(q => q.AvailableTo).HasColumnType("datetime2");
        builder.Property(q => q.CreatedAt).HasColumnType("datetime2").IsRequired();
        builder.Property(q => q.UpdatedAt).HasColumnType("datetime2").IsRequired();
        builder.HasOne(q => q.Course)
            .WithMany()
            .HasForeignKey(q => q.CourseId)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(q => q.Section)
            .WithMany(s => s.Quizzes)
            .HasForeignKey(q => q.SectionId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(q => q.Lecture)
            .WithMany()
            .HasForeignKey(q => q.LectureId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(q => q.Questions)
            .WithOne(qq => qq.Quiz)
            .HasForeignKey(qq => qq.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(q => q.Attempts)
            .WithOne(qa => qa.Quiz)
            .HasForeignKey(qa => qa.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}