using Exam_question_BE.HS.Core.DTOs.ApiResponse;
using Exam_question_BE.HS.Core.DTOs.Response;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers;
using Exam_question_BE.HS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exam_question_BE.HS.Web.Controllers
{
    [ApiController]
    [Route("api/question")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("filter")]
        public async Task<ActionResult<ApiResponse<PagedListApiResult<QuestionDTORes>>>> GetFilter(
            int page = 1, int pageSize = 10, string search = "", string sort = "", bool isQuestionActive = false, Guid? examId = null)
        {
            var exams = await _questionService.GetFilter(page, pageSize, search, sort, isQuestionActive, examId);
            return Ok(new ApiResponse<PagedListApiResult<QuestionDTORes>>(
                result: exams.ConvertPagedListApiResult()
                ));
        }

    }
}
