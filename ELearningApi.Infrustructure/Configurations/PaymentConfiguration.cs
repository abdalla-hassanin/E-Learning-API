using ELearningApi.Data.Entities;
using ELearningApi.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELearningApi.Infrustructure.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Amount).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(p => p.Status).IsRequired();
        builder.Property(p => p.Method).IsRequired().HasMaxLength(50);
        builder.Property(p => p.PaymentReferenceId).HasMaxLength(100);
        builder.Property(p => p.CreatedAt).HasColumnType("datetime2").IsRequired();
        builder.Property(p => p.UpdatedAt).HasColumnType("datetime2").IsRequired();
        builder.HasOne(p => p.Student)
            .WithMany()
            .HasForeignKey(p => p.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.Course)
            .WithMany()
            .HasForeignKey(p => p.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}