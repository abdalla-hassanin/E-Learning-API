using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.UpdateQuiz;

public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, ApiResponse<QuizDto>>
{
    private readonly IQuizService _quizService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public UpdateQuizCommandHandler(IQuizService quizService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizService = quizService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<QuizDto>> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
    {
        var existingQuiz = await _quizService.GetQuizByIdAsync(request.Id, cancellationToken);
        if (existingQuiz == null)
        {
            return _responseHandler.NotFound<QuizDto>($"Quiz with ID {request.Id} not found.");
        }

        _mapper.Map(request, existingQuiz);
        var updatedQuiz = await _quizService.UpdateQuizAsync(existingQuiz, cancellationToken);
        var quizDto = _mapper.Map<QuizDto>(updatedQuiz);
        return _responseHandler.Success(quizDto, "Quiz updated successfully.");
    }
}

