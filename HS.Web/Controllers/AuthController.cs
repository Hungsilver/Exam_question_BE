using Exam_question_BE.HS.Core.DTOs.Auth;
using Exam_question_BE.HS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exam_question_BE.HS.Web.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginReq login)
        {
            return Ok(await _authService.Login(login));
        }
        
        [HttpPost("/register")]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterUser userRegister)
        {
            var authres =await _authService.Register(userRegister);
            return Ok(authres);
        }
    }
}
