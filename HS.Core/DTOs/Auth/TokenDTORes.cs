namespace Exam_question_BE.HS.Core.DTOs.Auth
{
    public class TokenDTORes
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime Expired { get; set; }
    }
}
