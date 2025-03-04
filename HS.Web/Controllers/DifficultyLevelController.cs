using Exam_question_BE.HS.Core.DTOs.ApiResponse;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exam_question_BE.HS.Web.Controllers
{
    [ApiController]
    [Route("api/DifficultyLevel")]
    public class DifficultyLevelController : ControllerBase
    {
        private readonly IDifficultyLevelService _difficultyLevelService;
        public DifficultyLevelController(IDifficultyLevelService difficultyLevelService)
        {
            _difficultyLevelService = difficultyLevelService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<DifficultyLevel>>>> GetAll()
        {
            return Ok(new ApiResponse<IEnumerable<DifficultyLevel>>(
                result: await _difficultyLevelService.GetAll()
                ));
        }

    }
}
