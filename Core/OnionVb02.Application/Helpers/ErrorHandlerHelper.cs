using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;

namespace OnionVb02.Application.Helpers
{
    public static class ErrorHandlerHelper
    {
        public static async Task<T> ExecuteWithErrorHandling<T>(Func<Task<T>> operation, string operationName)
        {
            try
            {
                return await operation();
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (AppValidationException)
            {
                throw;
            }
            catch (AppBusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException($"{operationName} sırasında bir hata oluştu", ex);
            }
        }

        public static async Task ExecuteWithErrorHandling(Func<Task> operation, string operationName)
        {
            try
            {
                await operation();
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (AppValidationException)
            {
                throw;
            }
            catch (AppBusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException($"{operationName} sırasında bir hata oluştu", ex);
            }
        }
    }
}
