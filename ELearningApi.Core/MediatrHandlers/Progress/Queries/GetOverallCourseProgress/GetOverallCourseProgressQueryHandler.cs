using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Queries.GetOverallCourseProgress;

public class GetOverallCourseProgressQueryHandler : IRequestHandler<GetOverallCourseProgressQuery, ApiResponse<string>>
{
    private readonly IProgressService _progressService;
    private readonly ApiResponseHandler _responseHandler;

    public GetOverallCourseProgressQueryHandler(IProgressService progressService, ApiResponseHandler responseHandler)
    {
        _progressService = progressService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(GetOverallCourseProgressQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var overallProgress = await _progressService.GetOverallCourseProgressAsync(request.StudentId, request.CourseId);
            return _responseHandler.Success(overallProgress.ToString());
        }
        catch (ArgumentException ex)
        {
            return _responseHandler.NotFound<string>(ex.Message);
        }
    }
}