using System.ComponentModel.DataAnnotations;

namespace Exam_question_BE.HS.Core.DTOs.Auth
{
    public class LoginReq
    {
        [Required(ErrorMessage = "Username là bắt buộc.")]
        [StringLength(12, ErrorMessage = "Username không được vượt quá 12 ký tự.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 đến 16 kí tự.")]
        public required string Password { get; set; }
    }
}
