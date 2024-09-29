using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Commands.EnrollStudentInCourse;

public class EnrollStudentInCourseCommand : IRequest<ApiResponse<EnrollmentDto>>
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}