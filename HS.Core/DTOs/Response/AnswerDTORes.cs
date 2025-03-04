using Exam_question_BE.HS.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Exam_question_BE.HS.Core.DTOs.Response
{
    public class AnswerDTORes
    {
        public Guid Id { get; set; }
        public required Guid QuestionId { get; set; }
        //public required Question Question { get; set; }
        public required string Title { get; set; }
        //public bool IsCorrect { get; set; }
        public int OrderDisplay { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
