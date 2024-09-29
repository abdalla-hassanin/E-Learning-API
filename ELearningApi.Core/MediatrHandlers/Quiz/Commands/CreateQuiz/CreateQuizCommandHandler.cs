using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.CreateQuiz;

public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, ApiResponse<QuizDto>>
{
    private readonly IQuizService _quizService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public CreateQuizCommandHandler(IQuizService quizService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizService = quizService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<QuizDto>> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = _mapper.Map<Data.Entities.Quiz>(request);
        var createdQuiz = await _quizService.CreateQuizAsync(quiz, cancellationToken);
        var quizDto = _mapper.Map<QuizDto>(createdQuiz);
        return _responseHandler.Success(quizDto, "Quiz created successfully.");
    }
}
