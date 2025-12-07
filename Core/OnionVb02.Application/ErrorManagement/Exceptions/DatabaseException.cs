namespace OnionVb02.Application.ErrorManagement.Exceptions
{
    public class DatabaseException : BaseException
    {
        public DatabaseException(string message)
            : base(message, 500)
        {
        }

        public DatabaseException(string message, Exception innerException)
            : base($"{message}: {innerException.Message}", 500)
        {
        }
    }
}
