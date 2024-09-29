using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Enums;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.CreateLecture;

public class CreateLectureCommand : IRequest<ApiResponse<LectureDto>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public TimeSpan Duration { get; set; }
    public Guid SectionId { get; set; }
    public LectureType Type { get; set; }
    public string VideoUrl { get; set; }
}
