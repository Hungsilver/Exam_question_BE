using Exam_question_BE.HS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Exam_question_BE.HS.Core.Helpers
{
    public class GenerateCode
    {
        const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        const int CODE_COUNT = 8;
        private static Random random = new Random();
        public static async Task<string> GenerateUniqueCodeAsync(ApplicationDBContext context)
        {
            string code;
            bool isDuplicate;
            do
            {

                code = new string(Enumerable.Repeat(chars, CODE_COUNT)
                .Select(s => s[random.Next(s.Length)]).ToArray());

                isDuplicate = await context.Users.AnyAsync(u => u.Code == code);
            } while (isDuplicate);

            return code;
        }
    }
}
