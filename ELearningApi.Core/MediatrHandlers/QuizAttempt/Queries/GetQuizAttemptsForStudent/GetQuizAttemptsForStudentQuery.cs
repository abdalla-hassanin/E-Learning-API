using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptsForStudent;

public class GetQuizAttemptsForStudentQuery : IRequest<ApiResponse<IEnumerable<QuizAttemptDto>>>
{
    public Guid StudentId { get; set; }
    public Guid QuizId { get; set; }
}
