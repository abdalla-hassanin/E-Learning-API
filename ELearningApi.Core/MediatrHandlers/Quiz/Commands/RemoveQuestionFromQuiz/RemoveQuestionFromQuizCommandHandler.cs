using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.RemoveQuestionFromQuiz;

public class RemoveQuestionFromQuizCommandHandler : IRequestHandler<RemoveQuestionFromQuizCommand, ApiResponse<string>>
{
    private readonly IQuizService _quizService;
    private readonly ApiResponseHandler _responseHandler;

    public RemoveQuestionFromQuizCommandHandler(IQuizService quizService, ApiResponseHandler responseHandler)
    {
        _quizService = quizService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(RemoveQuestionFromQuizCommand request, CancellationToken cancellationToken)
    {
        await _quizService.RemoveQuestionFromQuizAsync(request.QuizId, request.QuestionId, cancellationToken);
        return _responseHandler.Success( "Question removed from quiz successfully.");
    }
}
