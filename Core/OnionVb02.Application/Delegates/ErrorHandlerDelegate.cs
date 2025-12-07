namespace OnionVb02.Application.Delegates
{
    public delegate Task<T> ErrorHandlerDelegate<T>(Func<Task<T>> operation);
    public delegate Task ErrorHandlerDelegate(Func<Task> operation);
}
