using Exam_question_BE.HS.Core.Interfaces.BaseEntity;

namespace Exam_question_BE.HS.Core.DTOs.Response
{
    public class UserDTORes : IBaseEntity
    {
        public Guid Id { get; set; }
        public required string Code { get; set; }
        public required string Username { get; set; }
        public required string FullName { get; set; }
        public string? Email { get; set; }
        public required string PasswordHash { get; set; }
        public string? Avatar { get; set; }
        public DateTime? BirthDate { get; set; }
        public required int Gender { get; set; } //nu - nam - gax
        public string? PhoneNumber { get; set; }
        public int? Status { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public IEnumerable<string> Roles { get; set; } = [];
    }
}
