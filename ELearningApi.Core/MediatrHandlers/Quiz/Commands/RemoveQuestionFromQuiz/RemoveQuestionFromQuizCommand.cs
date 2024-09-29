using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.RemoveQuestionFromQuiz;

public class RemoveQuestionFromQuizCommand : IRequest<ApiResponse<string>>
{
    public Guid QuizId { get; set; }
    public Guid QuestionId { get; set; }
}
