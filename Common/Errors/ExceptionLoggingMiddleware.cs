using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Errors
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionLoggingMiddleware> _logger;
        private const string ContentType = "application/json";

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

                httpContext.Response.ContentType = ContentType;
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
