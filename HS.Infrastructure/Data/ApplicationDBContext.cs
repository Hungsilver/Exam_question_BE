using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Exam_question_BE.HS.Infrastructure.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new RoleConfigurations());
        }
    }
}
