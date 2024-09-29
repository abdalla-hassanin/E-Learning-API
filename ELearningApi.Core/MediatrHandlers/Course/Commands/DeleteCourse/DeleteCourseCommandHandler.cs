using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Commands.DeleteCourse;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, ApiResponse<string>>
{
    private readonly ICourseService _courseService;
    private readonly ApiResponseHandler _responseHandler;

    public DeleteCourseCommandHandler(ICourseService courseService, ApiResponseHandler responseHandler)
    {
        _courseService = courseService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _courseService.DeleteCourseAsync(request.Id, cancellationToken);
            return _responseHandler.Success("Course deleted successfully.");
        }
        catch (KeyNotFoundException)
        {
            return _responseHandler.NotFound<string>($"Course with ID {request.Id} not found.");
        }
    }
}
