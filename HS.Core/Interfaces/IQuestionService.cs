using Exam_question_BE.HS.Core.DTOs.Response;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers;

namespace Exam_question_BE.HS.Core.Interfaces
{
    public interface IQuestionService
    {
        Task<PaginatedList<QuestionDTORes>> GetFilter(int page, int pageSize, string search, string sort, bool isActive,Guid? examId);
        Task<IEnumerable<QuestionDTORes>> GetAll();
        Task<Question> GetOne(Guid id);
        Task<Question> Update(Guid id, Question question);
        Task<bool> Remove(Guid id);
    }
}
