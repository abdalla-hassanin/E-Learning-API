using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.GetCourseRating;

public class GetCourseRatingQuery : IRequest<ApiResponse<string>>
{
    public Guid CourseId { get; set; }
}

