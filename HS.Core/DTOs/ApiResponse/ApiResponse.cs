namespace Exam_question_BE.HS.Core.DTOs.ApiResponse
{
    public record ApiResponse<T>(
        T? result = default,
        string message = "thành công",
        int code = StatusCodes.Status200OK,
        bool isOK = true);
}
