using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.GetCourseRating;

public class GetCourseRatingQueryHandler : IRequestHandler<GetCourseRatingQuery, ApiResponse<string>>
{
    private readonly ICourseService _courseService;
    private readonly ApiResponseHandler _responseHandler;

    public GetCourseRatingQueryHandler(ICourseService courseService, ApiResponseHandler responseHandler)
    {
        _courseService = courseService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(GetCourseRatingQuery request, CancellationToken cancellationToken)
    {
        var rating = await _courseService.GetCourseRatingAsync(request.CourseId, cancellationToken);
        return _responseHandler.Success(rating.ToString());
    }
}
