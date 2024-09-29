using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Queries.CheckEnrollmentStatus;

public class CheckEnrollmentStatusQuery : IRequest<ApiResponse<string>>
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}
