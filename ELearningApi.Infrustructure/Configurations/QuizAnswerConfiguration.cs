using ELearningApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class QuizAnswerConfiguration : IEntityTypeConfiguration<QuizAnswer>
{
    public void Configure(EntityTypeBuilder<QuizAnswer> builder)
    {
        builder.HasKey(qa => qa.Id);
        builder.Property(qa => qa.Id).ValueGeneratedOnAdd();
        builder.Property(qa => qa.AnswerText).IsRequired().HasMaxLength(500);
        builder.Property(qa => qa.IsCorrect).IsRequired();
        builder.Property(qa => qa.Explanation).HasMaxLength(1000);
        builder.Property(qa => qa.OrderIndex);
        builder.HasOne(qa => qa.Question)
            .WithMany(qq => qq.Answers)
            .HasForeignKey(qa => qa.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

