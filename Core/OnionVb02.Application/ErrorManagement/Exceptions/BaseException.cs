namespace OnionVb02.Application.ErrorManagement.Exceptions
{
    public abstract class BaseException : Exception
    {
        public int StatusCode { get; protected set; }
        public List<string> Errors { get; protected set; } = new();

        protected BaseException(string message, int statusCode = 500) : base(message)
        {
            StatusCode = statusCode;
        }

        protected BaseException(string message, List<string> errors, int statusCode = 500) : base(message)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}
