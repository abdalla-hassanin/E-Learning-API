using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.GenerateRandomQuiz;

public class GenerateRandomQuizCommandHandler : IRequestHandler<GenerateRandomQuizCommand, ApiResponse<QuizDto>>
{
    private readonly IQuizService _quizService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GenerateRandomQuizCommandHandler(IQuizService quizService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizService = quizService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<QuizDto>> Handle(GenerateRandomQuizCommand request, CancellationToken cancellationToken)
    {
        var randomQuiz = await _quizService.GenerateRandomQuizAsync(request.CourseId, request.QuestionCount, cancellationToken);
        var quizDto = _mapper.Map<QuizDto>(randomQuiz);
        return _responseHandler.Success(quizDto, "Random quiz generated successfully.");
    }
}