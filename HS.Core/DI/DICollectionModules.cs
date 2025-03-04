using Exam_question_BE.HS.Core.Interfaces;
using Exam_question_BE.HS.Core.Services;
using Exam_question_BE.HS.Infrastructure.Service;

namespace Exam_question_BE.HS.Core.DI
{
    public static class DICollectionModules
    {
        public static IServiceCollection AddServicesCollection(this IServiceCollection services)
        {
            services.AddScoped<JwtService>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IDifficultyLevelService,DifficultyLevelService>();
            services.AddScoped<IExamService,ExamService>();
            services.AddScoped<IQuestionService,QuestionService>();
            services.AddScoped<IAnswerService,AnswerService>();
            return services;
        }

        public static IServiceCollection AddRepositoriesCollection(this IServiceCollection services)
        {
            return services;
        }

    }
}
