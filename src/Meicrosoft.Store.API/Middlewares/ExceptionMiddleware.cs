using System.Net;
using System.Text.Json;

namespace Meicrosoft.Store.API.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionMiddleware> _logger = logger;

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, env);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            _logger.LogError(exception, "An internal server error has occurred");

            string result;

            if (env.IsDevelopment())
            {
                result = JsonSerializer.Serialize(new
                {
                    error = exception.Message,
                    stackTrace = exception.StackTrace
                });
            }
            else
            {
                result = JsonSerializer.Serialize(new
                {
                    error = "An internal server error has occurred"
                });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(result);
        }
    }
}
