using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_question_BE.HS.Core.Entities
{
    public class DifficultyLevel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar(11)")]
        public required string DifficultyName { get; set; }
    }
}
