using System.Net;
using System.Text.Json;
using ELearningApi.Core.Base.ApiResponse;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ELearningApi.Core.Base.MiddleWare
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        private readonly ApiResponseHandler _responseHandler;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _responseHandler = new ApiResponseHandler();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ApiResponse<string> response;
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case KeyNotFoundException keyNotFoundEx:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response = _responseHandler.NotFound<string>(keyNotFoundEx.Message);
                    break;

                case ValidationException validationEx:
                    context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    response = new ApiResponse<string>
                    {
                        StatusCode = HttpStatusCode.UnprocessableEntity,
                        Succeeded = false,
                        Message = "Validation errors occurred.",
                        Errors = validationEx.Errors.Select(x => x.ErrorMessage).ToList()
                    };
                    break;

                case UnauthorizedAccessException unauthorizedEx:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response = _responseHandler.Unauthorized<string>(unauthorizedEx.Message);
                    break;


                case DbUpdateException dbUpdateEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = _responseHandler.BadRequest<string>(dbUpdateEx.Message);
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    _logger.LogError(exception, "An unhandled exception has occurred.");
                    response = _responseHandler.BadRequest<string>(
                        "An unexpected error occurred. Please try again later.");
                    break;
            }

            var result = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(result);
        }
    }
}