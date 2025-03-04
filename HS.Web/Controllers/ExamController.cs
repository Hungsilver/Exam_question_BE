using Exam_question_BE.HS.Core.DTOs.ApiResponse;
using Exam_question_BE.HS.Core.DTOs.Request.exam;
using Exam_question_BE.HS.Core.DTOs.Response.exam;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers;
using Exam_question_BE.HS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exam_question_BE.HS.Web.Controllers
{
    [ApiController]
    [Route("api/Exam")]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Exam>>>> GetAll()
        {
            return Ok(new ApiResponse<IEnumerable<Exam>>(
                result: await _examService.GetAll()
                ));
        }

        [HttpGet("filter")]
        public async Task<ActionResult<ApiResponse<PagedListApiResult<Exam>>>> GetFilter(
            int page = 1, int pageSize = 10, string search = "", string sort = "", bool isQuestionActive = false)
        {
            var exams = await _examService.GetFilter(page, pageSize, search, sort, isQuestionActive);
            return Ok(new ApiResponse<PagedListApiResult<Exam>>(
                result: exams.ConvertPagedListApiResult()
                ));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ExamResultDTO>>> CheckAnswer([FromBody] SubmitExamDTO submitExam)
        {
            var examResultDTO = await _examService.CheckAnswer(submitExam);

            return Ok(new ApiResponse<ExamResultDTO>(
               result: examResultDTO
            ));
        }
    }
}
