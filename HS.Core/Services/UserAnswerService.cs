using AutoMapper;
using Exam_question_BE.HS.Core.DTOs.Request;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers;
using Exam_question_BE.HS.Core.Interfaces;
using Exam_question_BE.HS.Infrastructure.Data;

namespace Exam_question_BE.HS.Core.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<UserAnswerService> _logger;
        private readonly IMapper _mapper;
        public UserAnswerService(ApplicationDBContext context, ILogger<UserAnswerService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public Task<UserAnswer> Add(UserExamDTOReq userExam)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserAnswer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<UserAnswer>> GetFilter(int page, int pageSize, string search, string sort, bool isActive, Guid? examId, Guid? userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserAnswer> GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserAnswer> Update(Guid id, UserAnswer question)
        {
            throw new NotImplementedException();
        }
    }
}
