using ELearningApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class QuizQuestionConfiguration : IEntityTypeConfiguration<QuizQuestion>
{
    public void Configure(EntityTypeBuilder<QuizQuestion> builder)
    {
        builder.HasKey(qq => qq.Id);
        builder.Property(qq => qq.Id).ValueGeneratedOnAdd();
        builder.Property(qq => qq.QuestionText).IsRequired().HasMaxLength(1000);
        builder.Property(qq => qq.Type).IsRequired();
        builder.Property(qq => qq.Points).IsRequired();
        builder.Property(qq => qq.DifficultyLevel).IsRequired();
        builder.Property(qq => qq.Explanation).HasMaxLength(1000);
        builder.Property(qq => qq.OrderIndex).IsRequired();
        builder.HasOne(qq => qq.Quiz)
            .WithMany(q => q.Questions)
            .HasForeignKey(qq => qq.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(qq => qq.Answers)
            .WithOne(qa => qa.Question)
            .HasForeignKey(qa => qa.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(qq => qq.Media)
            .WithOne(qm => qm.Question)
            .HasForeignKey(qm => qm.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}