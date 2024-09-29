using System.Net;
using ELearningApi.Core.Base.ApiResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Base;

[ApiController]
public abstract class AppControllerBase : ControllerBase
{
    private IMediator? _mediator;

    // Lazily initialize the Mediator instance
    protected IMediator Mediator => (_mediator ??= HttpContext.RequestServices.GetService<IMediator>())!;

    // Generic method to create an ObjectResult based on ApiResponse
    protected ObjectResult CreateResponse<T>(ApiResponse<T> response) where T : class
    {
        return response.StatusCode switch
        {
            HttpStatusCode.OK => Ok(response),
            HttpStatusCode.Created => Created(string.Empty, response),
            HttpStatusCode.Unauthorized => Unauthorized(response),
            HttpStatusCode.BadRequest => BadRequest(response),
            HttpStatusCode.NotFound => NotFound(response),
            HttpStatusCode.Accepted => Accepted(response),
            HttpStatusCode.UnprocessableEntity => UnprocessableEntity(response),
            _ => BadRequest(response),
        };
    }
}