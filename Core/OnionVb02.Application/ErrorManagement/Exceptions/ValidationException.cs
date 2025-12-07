namespace OnionVb02.Application.ErrorManagement.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException(string message)
            : base(message, 400)
        {
        }

        public ValidationException(List<string> errors)
            : base("Validasyon hataları oluştu", errors, 400)
        {
        }

        public ValidationException(string message, List<string> errors)
            : base(message, errors, 400)
        {
        }
    }
}
