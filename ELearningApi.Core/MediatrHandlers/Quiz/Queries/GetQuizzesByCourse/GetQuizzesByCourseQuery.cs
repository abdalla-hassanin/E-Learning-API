using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesByCourse;

public class GetQuizzesByCourseQuery : IRequest<ApiResponse<IEnumerable<QuizDto>>>
{
    public Guid CourseId { get; set; }
}

