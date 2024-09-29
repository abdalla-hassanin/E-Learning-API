using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptsForQuiz;

public class GetQuizAttemptsForQuizQueryHandler : IRequestHandler<GetQuizAttemptsForQuizQuery, ApiResponse<IEnumerable<QuizAttemptDto>>>
{
    private readonly IQuizAttemptService _quizAttemptService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetQuizAttemptsForQuizQueryHandler(IQuizAttemptService quizAttemptService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizAttemptService = quizAttemptService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<QuizAttemptDto>>> Handle(GetQuizAttemptsForQuizQuery request, CancellationToken cancellationToken)
    {
        var results = await _quizAttemptService.GetQuizAttemptsForQuizAsync(request.QuizId, cancellationToken);
        var dtos = _mapper.Map<IEnumerable<QuizAttemptDto>>(results);
        return _responseHandler.Success(dtos);
    }
}
