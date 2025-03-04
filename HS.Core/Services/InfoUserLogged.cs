using Exam_question_BE.HS.Core.DTOs.Auth;
using Exam_question_BE.HS.Core.Exceptions;
using System.Security.Claims;

namespace Exam_question_BE.HS.Core.Services
{
    public class InfoUserLogged
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public InfoUserLogged(IHttpContextAccessor httpContext)
        {
            _httpContextAccessor = httpContext;
        }
        public UserByToken GetUserByToken()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var identity = httpContext?.User.Identity as ClaimsIdentity;
            if (identity == null)
            {
                throw new BadRequestException("Invalid token");
            }
            var userClaims = identity.Claims;
            var userId = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;
            var username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value;
            IEnumerable<string> roles = userClaims
                .Where(o => o.Type == ClaimTypes.Role)
                .Select(o => o.Value)
                .ToList();

            return new UserByToken(Guid.Parse(userId!), username!, roles);
        }

    }
}
