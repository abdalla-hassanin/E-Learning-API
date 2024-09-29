using ELearningApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class AttemptAnswerConfiguration : IEntityTypeConfiguration<AttemptAnswer>
{
    public void Configure(EntityTypeBuilder<AttemptAnswer> builder)
    {
        builder.HasKey(aa => aa.Id);
        builder.Property(aa => aa.Id).ValueGeneratedOnAdd();
        builder.Property(aa => aa.Response).IsRequired().HasMaxLength(1000);
        builder.Property(aa => aa.IsCorrect).IsRequired();
        builder.Property(aa => aa.PointsEarned).IsRequired();
        builder.Property(aa => aa.TimeTaken).HasColumnType("time").IsRequired();
        builder.HasOne(aa => aa.QuizAttempt)
            .WithMany(qa => qa.Answers)
            .HasForeignKey(aa => aa.QuizAttemptId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
