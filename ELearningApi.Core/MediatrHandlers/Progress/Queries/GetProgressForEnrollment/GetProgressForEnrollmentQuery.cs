using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Queries.GetProgressForEnrollment;

public class GetProgressForEnrollmentQuery : IRequest<ApiResponse<IEnumerable<ProgressDto>>>
{
    public Guid EnrollmentId { get; set; }
}
