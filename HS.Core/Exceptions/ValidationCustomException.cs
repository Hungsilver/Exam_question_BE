
namespace Exam_question_BE.HS.Core.Exceptions
{
    public class ValidationCustomException : Exception
    {
        public ValidationCustomException() : base("One or more validation failures have occurred.") { }
        public ValidationCustomException(string message) : base(message) { }
        public ValidationCustomException(string message, Exception innerException) : base(message, innerException) { }
        public ValidationCustomException(IEnumerable<IDictionary<string, IEnumerable<string>>> failures)
            : this()
        {
            Failures = failures;
        }

        public IEnumerable<IDictionary<string, IEnumerable<string>>> Failures { get; } = [];
    }
}
