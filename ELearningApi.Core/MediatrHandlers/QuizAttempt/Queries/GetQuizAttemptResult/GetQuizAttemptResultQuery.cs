using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptResult;

public class GetQuizAttemptResultQuery : IRequest<ApiResponse<QuizAttemptDto>>
{
    public Guid AttemptId { get; set; }
}

