using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Review.Queries.GetCourseAverageRating;

public class GetCourseAverageRatingQuery : IRequest<ApiResponse<string>>
{
    public Guid CourseId { get; set; }
}
