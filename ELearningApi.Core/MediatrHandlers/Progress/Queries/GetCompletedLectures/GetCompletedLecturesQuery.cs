using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Queries.GetCompletedLectures;

public class GetCompletedLecturesQuery : IRequest<ApiResponse<IEnumerable<ProgressDto>>>
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}