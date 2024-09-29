using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Review.Queries.GetReviewsForCourse;

public class GetReviewsForCourseQueryHandler : IRequestHandler<GetReviewsForCourseQuery, ApiResponse<PagedList<ReviewDto>>>
{
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetReviewsForCourseQueryHandler(IReviewService reviewService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _reviewService = reviewService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<PagedList<ReviewDto>>> Handle(GetReviewsForCourseQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _reviewService.GetReviewsForCourseAsync(request.CourseId, request.Page, request.PageSize, cancellationToken);
        var reviewDtos = _mapper.Map<IEnumerable<ReviewDto>>(reviews);
            
        var (_, totalCount) = reviews;

        var pagedReviews = new PagedList<ReviewDto>(reviewDtos, request.Page, request.PageSize, totalCount);

        return _responseHandler.Success(pagedReviews);
    }
}
