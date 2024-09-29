using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.UpdateQuestion;

public class UpdateQuestionCommand : IRequest<ApiResponse<QuizQuestionDto>>
{
    public Guid QuizId { get; set; }
    public QuizQuestionDto Question { get; set; }
}

