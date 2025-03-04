using AutoMapper;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers;
using Exam_question_BE.HS.Core.Interfaces;
using Exam_question_BE.HS.Infrastructure.Data;

namespace Exam_question_BE.HS.Core.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<AnswerService> _logger;
        private readonly IMapper _mapper;
        public AnswerService(ApplicationDBContext context, ILogger<AnswerService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public Task<IEnumerable<Answer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<Answer>> GetFilter(int page, int pageSize, string search, string sort, bool isActive)
        {
            throw new NotImplementedException();
        }

        public Task<Answer> GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Answer> Update(Guid id, Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
