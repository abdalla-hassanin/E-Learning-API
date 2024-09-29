using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Enums;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.UpdateLecture;

public class UpdateLectureCommand : IRequest<ApiResponse<LectureDto>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public TimeSpan Duration { get; set; }
    public int OrderIndex { get; set; }
    public LectureType Type { get; set; }
    public string VideoUrl { get; set; }
}