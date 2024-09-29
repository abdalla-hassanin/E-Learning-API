using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Queries.GetOverallCourseProgress;

public class GetOverallCourseProgressQuery : IRequest<ApiResponse<string>>
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}
