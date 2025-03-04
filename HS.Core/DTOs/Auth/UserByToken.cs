namespace Exam_question_BE.HS.Core.DTOs.Auth
{
    public record UserByToken(Guid UserId, string Username, IEnumerable<string> Role);
}
