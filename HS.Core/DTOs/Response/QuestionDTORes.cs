using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers.Enum;

namespace Exam_question_BE.HS.Core.DTOs.Response
{
    public class QuestionDTORes
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public Guid ExamId { get; set; }
        public Exam? Exam { get; set; } //co the khong thuoc bo de nao
        public required EDifficultyLevel DifficultyLevel { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<AnswerDTORes> Answers { get; set; } = new List<AnswerDTORes>();
    }
}
