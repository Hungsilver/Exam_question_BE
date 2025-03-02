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
            return services;
        }

        public static IServiceCollection AddRepositoriesCollection(this IServiceCollection services)
        {
            return services;
        }

    }
}
