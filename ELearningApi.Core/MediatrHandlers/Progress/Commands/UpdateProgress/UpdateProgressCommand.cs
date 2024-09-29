using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Enums;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Commands.UpdateProgress;

public class UpdateProgressCommand : IRequest<ApiResponse<ProgressDto>>
{
    public Guid EnrollmentId { get; set; }
    public Guid LectureId { get; set; }
    public decimal ProgressPercentage { get; set; }
    public ProgressStatus Status { get; set; }
}