
namespace Exam_question_BE.HS.Core.DTOs.Response.exam
{
    public class ExamResultDTO
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public Guid DifficultyLevelId { get; set; }
        public int ExamTime { get; set; }
        public int TotalQuestion { get; set; }
        public int TotalQuestionCorrect { get; set; }
        public int Score { get; set; }
        public List<AnswerResultDTO> AnswerResultDTOs { get; set; } = [];
    }
}
