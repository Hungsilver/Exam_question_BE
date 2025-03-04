using AutoMapper;
using AutoMapper.QueryableExtensions;
using Exam_question_BE.HS.Core.DTOs.Response;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Exceptions;
using Exam_question_BE.HS.Core.Helpers;
using Exam_question_BE.HS.Core.Interfaces;
using Exam_question_BE.HS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Exam_question_BE.HS.Core.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<QuestionService> _logger;
        private readonly IMapper _mapper;
        public QuestionService(ApplicationDBContext context, ILogger<QuestionService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionDTORes>> GetAll()
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .ProjectTo<QuestionDTORes>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PaginatedList<QuestionDTORes>> GetFilter(int page, int pageSize, string search, string sort, bool isActive, Guid? examId)
        {
            var query = _context.Questions
                .Include(q => q.Answers)
                .Select(q => new QuestionDTORes
                {
                    Id = q.Id,
                    DifficultyLevel = q.DifficultyLevel,
                    Title = q.Title,
                    Answers = q.Answers.Select(a => new AnswerDTORes
                    {
                        Id = a.Id,
                        QuestionId = a.QuestionId,
                        Title = a.Title,
                        CreatedDate = a.CreatedDate,
                        OrderDisplay = a.OrderDisplay
                    }).ToList(),
                    ExamId = q.ExamId,
                    IsActive = q.IsActive,
                }).AsQueryable();


            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.ApplyFilter("Title", search);
            }
            if (!string.IsNullOrWhiteSpace(sort))
            {
                query = query.ApplySort(sort);
            }
            if (examId != null)
            {
                query = query.Where(q => q.ExamId == examId);
            }
            if (isActive)
            {
                query = query.Where(e => e.IsActive == true);
            }
            query = query.OrderBy(q => q.Id);

            return await PaginatedList<QuestionDTORes>.CreateAsync(query.AsNoTracking(), page, pageSize);
        }

        public async Task<Question> GetOne(Guid id)
        {
            return await _context.Questions.FirstOrDefaultAsync(q => q.Id == id)
                ?? throw new NotFoundException($"cannot find question by id{id}");
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Question> Update(Guid id, Question question)
        {
            throw new NotImplementedException();
        }
    }
}
