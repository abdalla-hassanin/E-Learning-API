using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Commands.UnEnrollStudentFromCourse;

public class UnEnrollStudentFromCourseCommand : IRequest<ApiResponse<string>>
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}