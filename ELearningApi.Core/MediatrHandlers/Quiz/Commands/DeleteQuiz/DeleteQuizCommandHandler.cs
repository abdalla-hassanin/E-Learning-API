using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.DeleteQuiz;

public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommand, ApiResponse<string>>
{
    private readonly IQuizService _quizService;
    private readonly ApiResponseHandler _responseHandler;

    public DeleteQuizCommandHandler(IQuizService quizService, ApiResponseHandler responseHandler)
    {
        _quizService = quizService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
    {
        await _quizService.DeleteQuizAsync(request.Id, cancellationToken);
        return _responseHandler.Success( "Quiz deleted successfully.");
    }
}
