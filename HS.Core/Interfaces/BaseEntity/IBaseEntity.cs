using System.ComponentModel.DataAnnotations;

namespace Exam_question_BE.HS.Core.Interfaces.BaseEntity
{
    public abstract class IBaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
