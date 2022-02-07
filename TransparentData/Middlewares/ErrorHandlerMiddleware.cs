using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using TransparentData.Connections.Webcon;
using TransparentData.Exceptions;
using TransparentData.Models.Webcon;
using TransparentData.Other;

namespace TransparentData.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IWebconConnection _webcon;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger, IWebconConnection webcon)
        {
            _next = next;
            _logger = logger;
            _webcon = webcon;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var message = ex.Message;
                var statusCode = StatusCodes.Status500InternalServerError;

                switch (ex)
                {
                    case NoDataException e:
                        message = $"Brak argumentów - {e.Message}";
                        statusCode = StatusCodes.Status500InternalServerError;
                        break;

                    default:
                        break;
                }

                response.StatusCode = statusCode;
                _logger.LogError($"{statusCode} - {message} : {ex.Message}");
                var result = JsonSerializer.Serialize(new Error() { Message = message, Detail = ex.ToString(), StatusCode = statusCode });

                await response.WriteAsync(result);
            }
        }
    }
}
