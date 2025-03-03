using System.ComponentModel.DataAnnotations;

namespace Exam_question_BE.HS.Core.Entities
{
    public class Exam
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public required string Title { get; set; }
        public Guid DifficultyLevelId { get; set; }
        public required DifficultyLevel DifficultyLevel { get; set; }
        public int ExamTime { get; set; }
        public int TotalQuestion { get; set; }
        public int TotalQuestionCorrect { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
