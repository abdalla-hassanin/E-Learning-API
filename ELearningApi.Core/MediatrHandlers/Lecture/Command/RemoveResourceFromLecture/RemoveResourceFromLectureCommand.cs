using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.RemoveResourceFromLecture;

public class RemoveResourceFromLectureCommand : IRequest<ApiResponse<LectureDto>>
{
    public Guid LectureId { get; set; }
    public Guid ResourceId { get; set; }
}
