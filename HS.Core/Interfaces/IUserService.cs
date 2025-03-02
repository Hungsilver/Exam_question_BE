using Exam_question_BE.HS.Core.DTOs.Request;
using Exam_question_BE.HS.Core.DTOs.Response;
using Exam_question_BE.HS.Core.Helpers;

namespace Exam_question_BE.HS.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTORes>> GetAll();
        //Task<PaginatedList<UserDTORes>> GetPages(int page, int pageSize);
        Task<PaginatedList<UserDTORes>> GetFilter(int page, int pageSize, string search, string sort);
        Task<UserDTORes> GetOne(Guid id);
        Task<UserDTORes> Add(UserDTOReq user);
        Task<UserDTORes> Update(Guid id, UserDTOReq user);
        Task Delete(Guid id);
    }
}
