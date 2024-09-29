using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.GetCourseById;

public class GetCourseByIdQuery : IRequest<ApiResponse<CourseDto>>
{
    public Guid Id { get; set; }
}
