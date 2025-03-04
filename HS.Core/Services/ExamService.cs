using AutoMapper;
using Exam_question_BE.HS.Core.DTOs.Request.exam;
using Exam_question_BE.HS.Core.DTOs.Response.exam;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Exceptions;
using Exam_question_BE.HS.Core.Helpers;
using Exam_question_BE.HS.Core.Interfaces;
using Exam_question_BE.HS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Exam_question_BE.HS.Core.Services
{
    public class ExamService : IExamService
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<ExamService> _logger;
        private readonly IMapper _mapper;
        public ExamService(ApplicationDBContext context, ILogger<ExamService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }



        public async Task<IEnumerable<Exam>> GetAll()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task<PaginatedList<Exam>> GetFilter(int page, int pageSize, string search, string sort, bool isActive)
        {
            var query = _context.Exams
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.ApplyFilter("Title", search);
            }
            if (!string.IsNullOrWhiteSpace(sort))
            {
                query = query.ApplySort(sort);
            }
            if (isActive)
            {
                query = query.Where(e => e.Status == 1);
            }
            query = query.OrderBy(q => q.Id);

            return await PaginatedList<Exam>.CreateAsync(query.AsNoTracking(), page, pageSize);
        }
        public async Task<ExamResultDTO> CheckAnswer(SubmitExamDTO submitExamDTO)
        {
            int score = 0;
            List<AnswerResultDTO> examResultDTOs = new List<AnswerResultDTO>();

            //check exam
            var exam = await _context.Exams.FirstOrDefaultAsync(e => e.Id == submitExamDTO.ExamId)
                ?? throw new NotFoundException($"cannot find exam by id ={submitExamDTO.ExamId}");

            foreach (var submitAnswer in submitExamDTO.SubmitUserAnswers) /// co cau hoi va cau tl tu req. =>  tu cau hoi lay ra dap an va ss vs da tu req
            {
                var answerCorrect = await _context.Answers.FirstOrDefaultAsync(a => a.IsCorrect == true && a.QuestionId == submitAnswer.QuestionId);// lay ra da dung;
                var isCorrect = answerCorrect != null && answerCorrect.Id == submitAnswer.SelectedAnswerId ? true : false;
                if (isCorrect) score++;

                examResultDTOs.Add(new AnswerResultDTO
                {
                    QuestionId = submitAnswer.QuestionId,
                    IsCorrect = isCorrect,
                    CorrectAnswerId = answerCorrect != null ? answerCorrect.Id : Guid.Empty
                });
            }

            return new ExamResultDTO()
            {
                Id = exam.Id,
                Score = score,
                Title = exam.Title,
                DifficultyLevelId = exam.DifficultyLevelId,
                ExamTime = exam.ExamTime,
                TotalQuestion = exam.TotalQuestion,
                TotalQuestionCorrect = exam.TotalQuestionCorrect,
                AnswerResultDTOs = examResultDTOs
            };
        }

        public async Task<Exam> GetOne(Guid id)
        {
            var exam = await _context.Exams.FirstOrDefaultAsync(q => q.Id == id);
            return exam ?? throw new NotFoundException($"Cannot find exam by id={id}");
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Exam> Update(Guid id, Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}
