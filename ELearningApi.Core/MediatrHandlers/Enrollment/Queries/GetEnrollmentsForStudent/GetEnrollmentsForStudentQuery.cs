using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentsForStudent;

public class GetEnrollmentsForStudentQuery : IRequest<ApiResponse<IEnumerable<EnrollmentDto>>>
{
    public Guid StudentId { get; set; }
}
