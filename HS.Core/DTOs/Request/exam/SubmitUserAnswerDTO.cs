namespace Exam_question_BE.HS.Core.DTOs.Request.exam
{
    public class SubmitUserAnswerDTO
    {
        public Guid QuestionId { get; set; }
        public Guid SelectedAnswerId { get; set; }
    }
}
