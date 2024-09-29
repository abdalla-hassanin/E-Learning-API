using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Commands.MarkLectureComplete;

public class MarkLectureCompleteCommand : IRequest<ApiResponse<ProgressDto>>
{
    public Guid EnrollmentId { get; set; }
    public Guid LectureId { get; set; }
}
