using Exam_question_BE.HS.Core.DTOs.Request;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers;

namespace Exam_question_BE.HS.Core.Interfaces
{
    public interface IUserAnswerService
    {
        Task<PaginatedList<UserAnswer>> GetFilter(int page, int pageSize, string search, string sort, bool isActive, Guid? examId, Guid? userId);
        Task<IEnumerable<UserAnswer>> GetAll();
        Task<UserAnswer> GetOne(Guid id);
        Task<UserAnswer> Add(UserExamDTOReq userExam);
        Task<UserAnswer> Update(Guid id, UserAnswer question);
        Task<bool> Remove(Guid id);
    }
}
