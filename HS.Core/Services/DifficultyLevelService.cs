using AutoMapper;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Interfaces;
using Exam_question_BE.HS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Exam_question_BE.HS.Core.Services
{
    public class DifficultyLevelService : IDifficultyLevelService
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<DifficultyLevelService> _logger;
        private readonly IMapper _mapper;
        public DifficultyLevelService(ApplicationDBContext context, ILogger<DifficultyLevelService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DifficultyLevel>> GetAll()
        {
            return await _context.DifficultyLevels.ToListAsync();
        }
    }
}
