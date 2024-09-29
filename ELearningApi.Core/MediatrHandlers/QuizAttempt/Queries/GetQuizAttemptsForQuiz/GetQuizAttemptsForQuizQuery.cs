using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptsForQuiz;

public class GetQuizAttemptsForQuizQuery : IRequest<ApiResponse<IEnumerable<QuizAttemptDto>>>
{
    public Guid QuizId { get; set; }
}

