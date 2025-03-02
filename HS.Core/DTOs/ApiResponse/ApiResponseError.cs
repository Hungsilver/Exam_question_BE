namespace Exam_question_BE.HS.Core.DTOs.ApiResponse
{
    public record ApiResponseError<T>(int code, string message, T? result, bool isOK);
}
