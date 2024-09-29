using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.StartQuizAttempt;

public class StartQuizAttemptCommand : IRequest<ApiResponse<QuizAttemptDto>>
{
    public Guid StudentId { get; set; }
    public Guid QuizId { get; set; }
}
