using AutoMapper;
using Exam_question_BE.HS.Core.DTOs.Request;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers;
using Exam_question_BE.HS.Core.Interfaces;
using Exam_question_BE.HS.Infrastructure.Data;

namespace Exam_question_BE.HS.Core.Services
{
    public class UserExamService : IUserExamService
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<UserExamService> _logger;
        private readonly IMapper _mapper;
        public UserExamService(ApplicationDBContext context, ILogger<UserExamService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public Task<UserExam> Add(UserExamDTOReq userExam)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserExam>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<UserExam>> GetFilter(int page, int pageSize, string search, string sort, bool isActive, Guid? examId, Guid? userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserExam> GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserExam> Update(Guid id, UserExam question)
        {
            throw new NotImplementedException();
        }
    }
}
