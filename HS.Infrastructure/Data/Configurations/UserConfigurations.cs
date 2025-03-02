using Exam_question_BE.HS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam_question_BE.HS.Infrastructure.Data.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Code)
                .IsUnique();// code unique

            //n-n 1 chieu user
            builder.HasMany(u => u.Roles)
               .WithMany();

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWSEQUENTIALID()"); 
            
           
        }
    }
}
