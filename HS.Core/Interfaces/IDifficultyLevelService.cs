using Exam_question_BE.HS.Core.Entities;

namespace Exam_question_BE.HS.Core.Interfaces
{
    public interface IDifficultyLevelService
    {
        Task<IEnumerable<DifficultyLevel>> GetAll();
    }
}
