using Exam_question_BE.HS.Core.Helpers.Enum;
using System.ComponentModel.DataAnnotations;

namespace Exam_question_BE.HS.Core.Entities
{
    public class UserExam
    {
        [Key]
        public Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required User User { get; set; }
        public required Guid ExamId { get; set; }
        public required Exam Exam { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required string ExamName { get; set; }
        public EDifficultyLevel DifficultyLevel { get; set; }
        public bool IsPassed { get; set; } = false;
        public int Score { get; set; } = 0;
        public int ExamTime { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Status { get; set; } = 1;
    }
}
