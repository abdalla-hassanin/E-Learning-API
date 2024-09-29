using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.DeleteLecture;

public class DeleteLectureCommand : IRequest<ApiResponse<string>>
{
    public Guid Id { get; set; }
}
