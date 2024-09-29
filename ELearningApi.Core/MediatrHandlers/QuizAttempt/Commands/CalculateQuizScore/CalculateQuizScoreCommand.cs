using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.CalculateQuizScore;

public class CalculateQuizScoreCommand : IRequest<ApiResponse<QuizAttemptDto>>
{
    public Guid AttemptId { get; set; }
}
