using System.ComponentModel.DataAnnotations;

namespace Exam_question_BE.HS.Core.DTOs.Request.exam
{
    public class SubmitExamDTO
    {
        [Required]

        public required Guid ExamId { get; set; }
        public List<SubmitUserAnswerDTO> SubmitUserAnswers { get; set; } = [];
    }
}
