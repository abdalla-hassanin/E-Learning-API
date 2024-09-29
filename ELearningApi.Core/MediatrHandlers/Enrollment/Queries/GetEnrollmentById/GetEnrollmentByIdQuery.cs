using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentById;

public class GetEnrollmentByIdQuery : IRequest<ApiResponse<EnrollmentDto>>
{
    public Guid EnrollmentId { get; set; }
}
