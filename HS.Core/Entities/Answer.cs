using System.ComponentModel.DataAnnotations;

namespace Exam_question_BE.HS.Core.Entities
{
    public class Answer
    {
        [Key]
        public Guid Id { get; set; }
        public required Guid QuestionId { get; set; }
        public required Question Question { get; set; }
        [Required]
        public required string Title { get; set; }
        public bool IsCorrect { get; set; }
        public int OrderDisplay { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
