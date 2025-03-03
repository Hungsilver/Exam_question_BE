using Exam_question_BE.HS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_question_BE.HS.Infrastructure.Data.Configurations
{
    public class ExamConfigurations : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.HasMany<Question>()
                .WithOne(q => q.Exam)
                .HasForeignKey(q => q.ExamId)
                .IsRequired(false); // question maybe null

            builder.HasOne(e => e.DifficultyLevel)
                .WithMany()
                .HasForeignKey(e => e.DifficultyLevelId)
                .IsRequired();

        }
    }
}
