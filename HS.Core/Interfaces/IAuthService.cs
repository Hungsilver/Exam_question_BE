using Exam_question_BE.HS.Core.DTOs.Auth;

namespace Exam_question_BE.HS.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(LoginReq login);
        Task<AuthResponse> Register(RegisterUser userRegister);
        Task<TokenDTORes> RefreshToken(string token);
        Task RevokeToken(string token);
    }
}
