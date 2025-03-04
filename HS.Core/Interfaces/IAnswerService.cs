using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers;

namespace Exam_question_BE.HS.Core.Interfaces
{
    public interface IAnswerService
    {
        Task<PaginatedList<Answer>> GetFilter(int page, int pageSize, string search, string sort, bool isActive);
        Task<IEnumerable<Answer>> GetAll();
        Task<Answer> GetOne(Guid id);
        Task<Answer> Update(Guid id, Answer answer);
        Task<bool> Remove(Guid id);
    }
}
