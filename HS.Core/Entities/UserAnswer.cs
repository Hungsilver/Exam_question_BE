using System.ComponentModel.DataAnnotations;

namespace Exam_question_BE.HS.Core.Entities
{
    public class UserAnswer
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserExamId { get; set; }
        public required UserExam UserExam { get; set; } 
        public Guid AnswerId { get; set; }
        public required Answer Answer { get; set; } 
        public Guid QuestionId { get; set; }
        public required Question Question { get; set; }
        public required string TitleQuestion { get; set; }
        public required string TitleAnswer { get; set; }
    }
}
