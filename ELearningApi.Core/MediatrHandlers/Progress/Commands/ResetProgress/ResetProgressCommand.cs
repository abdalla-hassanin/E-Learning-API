using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Commands.ResetProgress;

public class ResetProgressCommand : IRequest<ApiResponse<string>>
{
    public Guid EnrollmentId { get; set; }
}
