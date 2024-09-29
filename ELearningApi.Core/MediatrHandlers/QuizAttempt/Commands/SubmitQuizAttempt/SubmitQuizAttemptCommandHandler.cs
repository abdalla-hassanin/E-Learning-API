using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Entities;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.SubmitQuizAttempt;

public class SubmitQuizAttemptCommandHandler : IRequestHandler<SubmitQuizAttemptCommand, ApiResponse<QuizAttemptDto>>
{
    private readonly IQuizAttemptService _quizAttemptService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public SubmitQuizAttemptCommandHandler(IQuizAttemptService quizAttemptService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizAttemptService = quizAttemptService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<QuizAttemptDto>> Handle(SubmitQuizAttemptCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var answers = _mapper.Map<IEnumerable<AttemptAnswer>>(request.Answers);
            var quizAttempt = await _quizAttemptService.SubmitQuizAttemptAsync(request.AttemptId, answers, cancellationToken);
            var quizAttemptDto = _mapper.Map<QuizAttemptDto>(quizAttempt);
            return _responseHandler.Success(quizAttemptDto, "Quiz attempt submitted successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<QuizAttemptDto>(ex.Message);
        }
    }
}
