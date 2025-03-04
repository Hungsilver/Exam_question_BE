using Exam_question_BE.HS.Core.DTOs.Request.exam;
using Exam_question_BE.HS.Core.DTOs.Response.exam;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers;

namespace Exam_question_BE.HS.Core.Interfaces
{
    public interface IExamService
    {
        Task<PaginatedList<Exam>> GetFilter(int page, int pageSize, string search, string sort, bool isActive);
        Task<IEnumerable<Exam>> GetAll();
        Task<ExamResultDTO> CheckAnswer(SubmitExamDTO submitExamDTO);
        Task<Exam> GetOne(Guid id);
        Task<Exam> Update(Guid id, Exam exam);
        Task<bool> Remove(Guid id);
    }
}
