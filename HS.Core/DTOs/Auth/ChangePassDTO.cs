using System.ComponentModel.DataAnnotations;

namespace Exam_question_BE.HS.Core.DTOs.Auth
{
    public class ChangePassDTO
    {
        [Required(ErrorMessage = "Password cannot empty")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "6-30 kí tự")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "NewPassword cannot empty")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "6-30 kí tự")]
        public required string NewPassword { get; set; }
    }
}
