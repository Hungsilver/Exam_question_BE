using Exam_question_BE.HS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_question_BE.HS.Infrastructure.Data.Configurations
{
    public class UserExamConfigurations : IEntityTypeConfiguration<UserExam>
    {
        public void Configure(EntityTypeBuilder<UserExam> builder)
        {
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.HasOne(ux => ux.User)
                .WithMany()
                .HasForeignKey(ux => ux.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ux => ux.Exam)
                .WithMany()
                .HasForeignKey(ux => ux.ExamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
