using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers.Enum;

namespace Exam_question_BE.HS.Core.DTOs.Request
{
    public class UserExamDTOReq
    {
        public Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required Guid ExamId { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required string ExamName { get; set; }
        public EDifficultyLevel DifficultyLevel { get; set; }
        public bool IsPassed { get; set; } = false;
        public int Score { get; set; } = 0;
        public int ExamTime { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Status { get; set; } //fr:1 ; end:0
    }
}
