using System.ComponentModel.DataAnnotations;

namespace Exam_question_BE.HS.Core.Entities
{
    public class Exam
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
