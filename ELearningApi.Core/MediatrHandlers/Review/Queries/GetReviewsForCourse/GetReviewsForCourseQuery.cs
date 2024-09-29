using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Review.Queries.GetReviewsForCourse;

public class GetReviewsForCourseQuery : IRequest<ApiResponse<PagedList<ReviewDto>>>
{
    public Guid CourseId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
