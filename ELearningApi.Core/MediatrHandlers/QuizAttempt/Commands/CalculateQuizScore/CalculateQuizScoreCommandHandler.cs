using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.CalculateQuizScore;

public class CalculateQuizScoreCommandHandler : IRequestHandler<CalculateQuizScoreCommand, ApiResponse<QuizAttemptDto>>
{
    private readonly IQuizAttemptService _quizAttemptService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public CalculateQuizScoreCommandHandler(IQuizAttemptService quizAttemptService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizAttemptService = quizAttemptService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<QuizAttemptDto>> Handle(CalculateQuizScoreCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var quizAttempt = await _quizAttemptService.CalculateQuizScoreAsync(request.AttemptId, cancellationToken);
            var quizAttemptDto = _mapper.Map<QuizAttemptDto>(quizAttempt);
            return _responseHandler.Success(quizAttemptDto, "Quiz score calculated successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<QuizAttemptDto>(ex.Message);
        }
    }
}
