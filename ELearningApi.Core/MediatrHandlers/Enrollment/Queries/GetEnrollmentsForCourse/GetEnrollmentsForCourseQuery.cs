using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentsForCourse;

public class GetEnrollmentsForCourseQuery : IRequest<ApiResponse<IEnumerable<EnrollmentDto>>>
{
    public Guid CourseId { get; set; }
}
