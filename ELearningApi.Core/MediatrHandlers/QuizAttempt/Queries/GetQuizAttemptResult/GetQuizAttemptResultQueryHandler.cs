using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptResult;

public class GetQuizAttemptResultQueryHandler : IRequestHandler<GetQuizAttemptResultQuery, ApiResponse<QuizAttemptDto>>
{
    private readonly IQuizAttemptService _quizAttemptService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetQuizAttemptResultQueryHandler(IQuizAttemptService quizAttemptService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizAttemptService = quizAttemptService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<QuizAttemptDto>> Handle(GetQuizAttemptResultQuery request, CancellationToken cancellationToken)
    {
        var result = await _quizAttemptService.GetQuizAttemptResultAsync(request.AttemptId, cancellationToken);
        if (result == null)
        {
            return _responseHandler.NotFound<QuizAttemptDto>("Quiz attempt not found.");
        }
        var dto = _mapper.Map<QuizAttemptDto>(result);
        return _responseHandler.Success(dto);
    }
}
