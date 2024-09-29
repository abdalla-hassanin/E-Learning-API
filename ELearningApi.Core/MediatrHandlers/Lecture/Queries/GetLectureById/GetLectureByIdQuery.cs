using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Queries.GetLectureById;

public class GetLectureByIdQuery : IRequest<ApiResponse<LectureDto>>
{
    public Guid Id { get; set; }
}
