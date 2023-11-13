using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BooksWebApi.Repositories
{
    public class ExceptionMiddleware : IMiddleware
    {

        public ExceptionMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = 500;
            var response = new
            {
                Status = statusCode,
                Code = "System Error",
                Detail = exception.Message,
                Message = "Unexpected error occured"
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
