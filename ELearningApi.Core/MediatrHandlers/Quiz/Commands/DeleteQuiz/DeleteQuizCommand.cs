using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.DeleteQuiz;

public class DeleteQuizCommand : IRequest<ApiResponse<string>>
{
    public Guid Id { get; set; }
}
