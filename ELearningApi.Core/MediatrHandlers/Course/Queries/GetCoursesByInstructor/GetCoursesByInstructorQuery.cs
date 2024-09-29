using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.GetCoursesByInstructor;

public class GetCoursesByInstructorQuery : IRequest<ApiResponse<IEnumerable<CourseDto>>>
{
    public Guid InstructorId { get; set; }
}