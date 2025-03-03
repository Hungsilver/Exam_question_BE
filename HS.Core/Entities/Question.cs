using Exam_question_BE.HS.Core.Helpers.Enum;
using System.ComponentModel.DataAnnotations;

namespace Exam_question_BE.HS.Core.Entities
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public required string Title { get; set; }
        public Guid ExamId { get; set; }
        public Exam? Exam { get; set; } //co the khong thuoc bo de nao
        public required EDifficultyLevel DifficultyLevel { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
