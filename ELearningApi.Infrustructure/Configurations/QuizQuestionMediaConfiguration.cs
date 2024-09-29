using ELearningApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class QuizQuestionMediaConfiguration : IEntityTypeConfiguration<QuizQuestionMedia>
{
    public void Configure(EntityTypeBuilder<QuizQuestionMedia> builder)
    {
        builder.HasKey(qqm => qqm.Id);
        builder.Property(qqm => qqm.Id).ValueGeneratedOnAdd();
        builder.Property(qqm => qqm.Url).IsRequired().HasMaxLength(500);
        builder.Property(qqm => qqm.Type).IsRequired();
        builder.HasOne(qqm => qqm.Question)
            .WithMany(qq => qq.Media)
            .HasForeignKey(qqm => qqm.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
