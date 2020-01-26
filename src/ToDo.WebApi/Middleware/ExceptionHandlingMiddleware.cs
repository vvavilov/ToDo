using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using ToDo.Domain.Exceptions;

namespace ToDo.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleException(context, exception);
            }
        }

        private async Task HandleException(HttpContext context, Exception exception)
        {
            var statusCode = StatusCodes.Status500InternalServerError;
            string? result = null;

            switch (exception)
            {
                case NotFoundException notFound:
                    statusCode = StatusCodes.Status404NotFound;
                    result = notFound.Message;
                    break;
            }

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = statusCode;

            result ??= exception.Message;
            result = JsonSerializer.Serialize(new { result });

            await context.Response.WriteAsync(result);

        }
    }
}
