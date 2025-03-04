using Exam_question_BE.HS.Core.DTOs.Request;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers;

namespace Exam_question_BE.HS.Core.Interfaces
{
    public interface IUserExamService
    {
        Task<PaginatedList<UserExam>> GetFilter(int page, int pageSize, string search, string sort, bool isActive, Guid? examId, Guid? userId);
        Task<IEnumerable<UserExam>> GetAll();
        Task<UserExam> GetOne(Guid id);
        Task<UserExam> Add(UserExamDTOReq userExam);
        Task<UserExam> Update(Guid id, UserExam question);
        Task<bool> Remove(Guid id);
    }
}
