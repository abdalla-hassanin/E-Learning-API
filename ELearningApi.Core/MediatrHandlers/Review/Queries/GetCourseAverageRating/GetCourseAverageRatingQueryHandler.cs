using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Review.Queries.GetCourseAverageRating;

public class GetCourseAverageRatingQueryHandler : IRequestHandler<GetCourseAverageRatingQuery, ApiResponse<string>>
{
    private readonly IReviewService _reviewService;
    private readonly ApiResponseHandler _responseHandler;

    public GetCourseAverageRatingQueryHandler(IReviewService reviewService, ApiResponseHandler responseHandler)
    {
        _reviewService = reviewService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(GetCourseAverageRatingQuery request, CancellationToken cancellationToken)
    {
        var averageRating = await _reviewService.CalculateAverageRatingAsync(request.CourseId, cancellationToken);
        return _responseHandler.Success(averageRating.ToString());
    }
}
