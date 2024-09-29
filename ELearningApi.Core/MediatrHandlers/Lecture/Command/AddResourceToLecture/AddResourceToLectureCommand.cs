using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Enums;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.AddResourceToLecture;

public class AddResourceToLectureCommand : IRequest<ApiResponse<LectureDto>>
{
    public Guid LectureId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public ResourceType Type { get; set; }
}