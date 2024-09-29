using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.SubmitQuizAttempt;

public class SubmitQuizAttemptCommand : IRequest<ApiResponse<QuizAttemptDto>>
{
    public Guid AttemptId { get; set; }
    public IEnumerable<AttemptAnswerDto> Answers { get; set; }
}
