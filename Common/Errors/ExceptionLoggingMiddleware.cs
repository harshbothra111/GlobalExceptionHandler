using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace Errors
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionLoggingMiddleware> _logger;
        private const string _contentType = "application/json";

        public ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ExceptionLoggingMiddleware> logger)
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
                _logger.LogError(ex, "Exception has been thrown");

                httpContext.Response.ContentType = _contentType;
                httpContext.Response.StatusCode = GetHttpStatusCode(ex);

                var exceptionMessage = FormatErrorMessage(ex);
                await httpContext.Response.WriteAsync(exceptionMessage);
            }
        }

        private string FormatErrorMessage(Exception ex) =>
            ex switch
            {
                ClaimNotFoundException claimNotFoundException => JsonConvert.SerializeObject(
                    new ErrorMessage(GetHttpStatusCode(claimNotFoundException), claimNotFoundException.Message)),
                PolicyNotFoundException policyNotFoundException => JsonConvert.SerializeObject(
                    new ErrorMessage(GetHttpStatusCode(policyNotFoundException), policyNotFoundException.Message)),
                _ => JsonConvert.SerializeObject(new ErrorMessage(GetHttpStatusCode(ex), ex.Message)),
            };

        private int GetHttpStatusCode(Exception ex)
            => ex switch
            {
                ClaimNotFoundException _ => (int)HttpStatusCode.NotFound,
                PolicyNotFoundException _ => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };
    }
}
