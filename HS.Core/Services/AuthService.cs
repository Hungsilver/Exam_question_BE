using Exam_question_BE.HS.Core.DTOs.Auth;
using Exam_question_BE.HS.Core.Exceptions;
using Exam_question_BE.HS.Core.Interfaces;
using Exam_question_BE.HS.Infrastructure.Data;
using Exam_question_BE.HS.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

namespace Exam_question_BE.HS.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDBContext _context;
        private ILogger<AuthService> _logger;
        private readonly JwtService _jwtService;
        private readonly int ACCESS_TOKEN_MINUTE = 10 * 60; //10 hour
        public AuthService(ApplicationDBContext context
            , ILogger<AuthService> logger
            , JwtService jwtService)
        {
            _context = context;
            _logger = logger;
            _jwtService = jwtService;
        }

        public async Task<AuthResponse> Login(LoginReq loginReq)
        {
            if (string.IsNullOrWhiteSpace(loginReq.Username) || string.IsNullOrWhiteSpace(loginReq.Password))
            {
                _logger.LogInformation("user or passs null");
                throw new BadRequestException("bad request by login null");
            }
            var loweredUsername = loginReq.Username.ToLower(); // chu thuong
            var user = await _context.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Username.Equals(loweredUsername));

            if (user == null)
            {
                throw new BadRequestException("Username or password invalid");
            }
            if (!PasswordService.VerifyPassword(loginReq.Password, user.PasswordHash))
            {
                throw new BadRequestException("Username or password invalid");
            }
            var expiresAccesstoken = DateTime.UtcNow.AddHours(ACCESS_TOKEN_MINUTE);
            IEnumerable<string> Roles = user.Roles.Select(r => r.Name!).ToList();
            string accessToken = _jwtService.GenerateToken(user.Id.ToString(), user.Username, expiresAccesstoken, Roles);

            return new AuthResponse(user.Id, user.FullName, user.Code, accessToken, expiresAccesstoken, Roles);
        }
        public Task<AuthResponse> Register(RegisterUser userRegister)
        {
            throw new NotImplementedException();
        }

        public Task<TokenDTORes> RefreshToken(string token)
        {
            throw new NotImplementedException();
        }

        public Task RevokeToken(string token)
        {
            throw new NotImplementedException();
        }


    }
}
