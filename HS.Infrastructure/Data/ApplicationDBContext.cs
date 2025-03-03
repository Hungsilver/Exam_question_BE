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
        public DbSet<Answer> Answers { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<UserExam> UserExams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new RoleConfigurations());
            modelBuilder.ApplyConfiguration(new ExamConfigurations());
            modelBuilder.ApplyConfiguration(new DifficultyLevelConfigurations());
            modelBuilder.ApplyConfiguration(new UserExamConfigurations());
            modelBuilder.ApplyConfiguration(new UserAnswerConfigurations());
            modelBuilder.ApplyConfiguration(new QuestionConfigurations());
            modelBuilder.ApplyConfiguration(new AnswerConfigurations());
        }
    }
}
