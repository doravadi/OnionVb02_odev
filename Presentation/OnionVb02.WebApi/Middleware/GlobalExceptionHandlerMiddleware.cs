using System.Net;
using System.Text.Json;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;

namespace OnionVb02.WebApi.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new
            {
                isSuccess = false,
                message = exception.Message,
                errors = new List<string>(),
                statusCode = HttpStatusCode.InternalServerError
            };

            switch (exception)
            {
                case AppValidationException validationException:
                    response = new
                    {
                        isSuccess = false,
                        message = validationException.Message,
                        errors = validationException.Errors,
                        statusCode = (HttpStatusCode)validationException.StatusCode
                    };
                    context.Response.StatusCode = validationException.StatusCode;
                    break;

                case AppNotFoundException notFoundException:
                    response = new
                    {
                        isSuccess = false,
                        message = notFoundException.Message,
                        errors = notFoundException.Errors,
                        statusCode = (HttpStatusCode)notFoundException.StatusCode
                    };
                    context.Response.StatusCode = notFoundException.StatusCode;
                    break;

                case AppBusinessException businessException:
                    response = new
                    {
                        isSuccess = false,
                        message = businessException.Message,
                        errors = businessException.Errors,
                        statusCode = (HttpStatusCode)businessException.StatusCode
                    };
                    context.Response.StatusCode = businessException.StatusCode;
                    break;

                case AppDatabaseException databaseException:
                    response = new
                    {
                        isSuccess = false,
                        message = "Veritabanı işlemi sırasında bir hata oluştu",
                        errors = new List<string> { databaseException.Message },
                        statusCode = (HttpStatusCode)databaseException.StatusCode
                    };
                    context.Response.StatusCode = databaseException.StatusCode;
                    break;

                default:
                    response = new
                    {
                        isSuccess = false,
                        message = "Beklenmeyen bir hata oluştu",
                        errors = new List<string> { exception.Message },
                        statusCode = HttpStatusCode.InternalServerError
                    };
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var jsonResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }

    public static class GlobalExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
