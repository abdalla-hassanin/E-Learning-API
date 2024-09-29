using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Entities;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.AddQuestionToQuiz;

public class AddQuestionToQuizCommandHandler : IRequestHandler<AddQuestionToQuizCommand, ApiResponse<QuizQuestionDto>>
{
    private readonly IQuizService _quizService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public AddQuestionToQuizCommandHandler(IQuizService quizService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizService = quizService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<QuizQuestionDto>> Handle(AddQuestionToQuizCommand request, CancellationToken cancellationToken)
    {
        var question = _mapper.Map<QuizQuestion>(request.Question);
        var addedQuestion = await _quizService.AddQuestionToQuizAsync(request.QuizId, question, cancellationToken);
        var questionDto = _mapper.Map<QuizQuestionDto>(addedQuestion);
        return _responseHandler.Success(questionDto, "Question added to quiz successfully.");
    }
}
