using System.Net.Mail;
using FluentValidation;
using PerfumeShop.Application.Exceptions;
using PerfumeShop.Application.Logging;

namespace PerfumeShop.API.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionLogger _logger;

        public GlobalExceptionHandler(RequestDelegate next, IExceptionLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);

                httpContext.Response.ContentType = "application/json";
                object? response = null;
                var statusCode = StatusCodes.Status500InternalServerError;

                if (ex is ValidationException e)
                {
                    statusCode = StatusCodes.Status422UnprocessableEntity;
                    response = new
                    {
                        errors = e.Errors.Select(x => new
                        {
                            property = x.PropertyName,
                            errorMessage = x.ErrorMessage
                        })
                    };
                }

                if (ex is ForbiddenUseCaseExecutionException)
                {
                    statusCode = StatusCodes.Status403Forbidden;
                }

                if (ex is NotFountException)
                {
                    statusCode = StatusCodes.Status404NotFound;
                }

                if (ex is SmtpException)
                {
                    statusCode = StatusCodes.Status406NotAcceptable;
                    response = new
                    {
                        errors = ex.Message,
                        success = "Your account has been created, but our mail service is down at the moment!"
                    };
                }

                httpContext.Response.StatusCode = statusCode;

                if (response != null)
                {
                    await httpContext.Response.WriteAsJsonAsync(response);
                }
            }
        }
    }
}
