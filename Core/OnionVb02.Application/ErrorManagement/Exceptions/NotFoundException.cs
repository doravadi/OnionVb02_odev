namespace OnionVb02.Application.ErrorManagement.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message)
            : base(message, 404)
        {
        }

        public NotFoundException(string entityName, object id)
            : base($"{entityName} bulunamadı. Id: {id}", 404)
        {
        }
    }
}
