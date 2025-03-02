namespace Exam_question_BE.HS.Core.DTOs.Auth
{
        public record AuthResponse(Guid UserId,
       string FullName,
       string Code,
       string AccessToken,
       //string RefreshToken,
       DateTime Expires,
       IEnumerable<string> Roles);
}
