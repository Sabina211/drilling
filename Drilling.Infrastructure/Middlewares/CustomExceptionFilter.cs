using Drilling.Exceptions;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Net;
using Drilling.Infrastructure.Exceptions;

namespace Drilling.Infrastructure.Middlewares
{
    public class CustomExceptionFilter
    {
        private readonly RequestDelegate next;

        public CustomExceptionFilter(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
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

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            HttpStatusCode status;
            var stackTrace = string.Empty;
            var data = (object)null;
            string result = "";

            switch (exception)
            {
                case EntityNotFoundException e:
                    status = HttpStatusCode.NotFound;
                    break;
                case DrillingException e:
                    status = HttpStatusCode.BadRequest;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    stackTrace = exception.StackTrace;
                    break;
            }

            result = JsonSerializer.Serialize(new
            {
                error = exception?.Message
            }, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            response.StatusCode = (int)status;
            return response.WriteAsync(result);
        }
    }
}
