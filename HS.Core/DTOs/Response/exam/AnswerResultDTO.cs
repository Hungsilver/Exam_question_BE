namespace Exam_question_BE.HS.Core.DTOs.Response.exam
{
    public class AnswerResultDTO
    {
        public Guid QuestionId { get; set; }
        public Guid CorrectAnswerId { get; set; }
        public bool IsCorrect { get; set; }

    }
}
