using AutoMapper;
using Exam_question_BE.HS.Core.DTOs.ApiResponse;
using Exam_question_BE.HS.Core.DTOs.Request;
using Exam_question_BE.HS.Core.DTOs.Response;
using Exam_question_BE.HS.Core.Helpers;
using Exam_question_BE.HS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exam_question_BE.HS.Web.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedListApiResult<UserDTORes>>>> GetFilter(int page = 1, int pageSize = 10, string search = "", string sort = "")
        {
            var users = await _userService.GetFilter(page, pageSize, search, sort);
            return Ok(new ApiResponse<PagedListApiResult<UserDTORes>>(
                result: users.ConvertPagedListApiResult()
                ));
        }

        [HttpPost]
        public async Task<ActionResult<UserDTORes>> AddUser([FromBody] UserDTOReq userReq)
        {
            var user = await _userService.Add(userReq);
            return Ok(new ApiResponse<UserDTORes>(
                result: user
                ));
        }
    }
}
