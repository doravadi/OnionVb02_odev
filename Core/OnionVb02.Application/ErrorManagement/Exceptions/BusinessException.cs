namespace OnionVb02.Application.ErrorManagement.Exceptions
{
    public class BusinessException : BaseException
    {
        public BusinessException(string message)
            : base(message, 400)
        {
        }

        public BusinessException(string message, List<string> errors)
            : base(message, errors, 400)
        {
        }
    }
}
