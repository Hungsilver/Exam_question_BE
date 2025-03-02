namespace Exam_question_BE.HS.Core.DTOs.Request
{
    public class UserDTOReq
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string FullName { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public DateTime? BirthDate { get; set; }
        public required int Gender { get; set; } //nu - nam - gax
        public string? PhoneNumber { get; set; }
    }
}
