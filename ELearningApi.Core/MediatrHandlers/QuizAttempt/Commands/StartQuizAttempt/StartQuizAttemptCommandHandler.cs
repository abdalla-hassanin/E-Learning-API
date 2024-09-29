using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.StartQuizAttempt;

public class StartQuizAttemptCommandHandler : IRequestHandler<StartQuizAttemptCommand, ApiResponse<QuizAttemptDto>>
{
    private readonly IQuizAttemptService _quizAttemptService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public StartQuizAttemptCommandHandler(IQuizAttemptService quizAttemptService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizAttemptService = quizAttemptService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<QuizAttemptDto>> Handle(StartQuizAttemptCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var quizAttempt = await _quizAttemptService.StartQuizAttemptAsync(request.StudentId, request.QuizId, cancellationToken);
            var quizAttemptDto = _mapper.Map<QuizAttemptDto>(quizAttempt);
            return _responseHandler.Success(quizAttemptDto, "Quiz attempt started successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<QuizAttemptDto>(ex.Message);
        }
    }
}
