using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Exam_question_BE.HS.Core.DTOs.Auth
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Username là bắt buộc.")]
        [StringLength(12, ErrorMessage = "Username không được vượt quá 12 ký tự.")]
        public required string Username { get; set; }

        [Range(8, 16, ErrorMessage = "Mật khẩu phải từ 8 đến 16 kí tự.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Tên là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Tên không được vượt quá 50 ký tự.")]
        public required string FullName { get; set; }

    }
}
