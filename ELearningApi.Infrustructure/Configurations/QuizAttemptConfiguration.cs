using ELearningApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class QuizAttemptConfiguration : IEntityTypeConfiguration<QuizAttempt>
{
    public void Configure(EntityTypeBuilder<QuizAttempt> builder)
    {
        builder.HasKey(qa => qa.Id);
        builder.Property(qa => qa.Id).ValueGeneratedOnAdd();
        builder.Property(qa => qa.StartTime).HasColumnType("datetime2").IsRequired();
        builder.Property(qa => qa.EndTime).HasColumnType("datetime2");
        builder.Property(qa => qa.Score).IsRequired();
        builder.Property(qa => qa.IsPassed).IsRequired();
        builder.HasOne(qa => qa.Student)
            .WithMany()
            .HasForeignKey(qa => qa.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(qa => qa.Quiz)
            .WithMany(q => q.Attempts)
            .HasForeignKey(qa => qa.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(qa => qa.Answers)
            .WithOne(aa => aa.QuizAttempt)
            .HasForeignKey(aa => aa.QuizAttemptId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
