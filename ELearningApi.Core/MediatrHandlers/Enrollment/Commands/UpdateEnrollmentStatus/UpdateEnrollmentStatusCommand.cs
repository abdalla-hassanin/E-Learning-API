using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Enums;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Commands.UpdateEnrollmentStatus;

public class UpdateEnrollmentStatusCommand : IRequest<ApiResponse<EnrollmentDto>>
{
    public Guid EnrollmentId { get; set; }
    public EnrollmentStatus NewStatus { get; set; }
}

