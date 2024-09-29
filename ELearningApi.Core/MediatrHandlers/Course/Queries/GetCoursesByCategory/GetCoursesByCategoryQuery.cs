using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.GetCoursesByCategory;

public class GetCoursesByCategoryQuery : IRequest<ApiResponse<IEnumerable<CourseDto>>>
{
    public Guid CategoryId { get; set; }
}