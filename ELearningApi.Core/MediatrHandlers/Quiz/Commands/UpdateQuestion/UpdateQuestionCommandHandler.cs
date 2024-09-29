using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Entities;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.UpdateQuestion;

public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, ApiResponse<QuizQuestionDto>>
{
    private readonly IQuizService _quizService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public UpdateQuestionCommandHandler(IQuizService quizService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizService = quizService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<QuizQuestionDto>> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = _mapper.Map<QuizQuestion>(request.Question);
        var updatedQuestion = await _quizService.UpdateQuestionAsync(question, cancellationToken);
        var questionDto = _mapper.Map<QuizQuestionDto>(updatedQuestion);
        return _responseHandler.Success(questionDto, "Question updated successfully.");
    }
}
