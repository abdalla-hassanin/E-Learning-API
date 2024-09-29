using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizById;

public class GetQuizByIdQueryHandler : IRequestHandler<GetQuizByIdQuery, ApiResponse<QuizDto>>
{
    private readonly IQuizService _quizService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetQuizByIdQueryHandler(IQuizService quizService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizService = quizService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<QuizDto>> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
    {
        var quiz = await _quizService.GetQuizByIdAsync(request.QuizId, cancellationToken);
        if (quiz == null)
        {
            return _responseHandler.NotFound<QuizDto>("Quiz not found.");
        }

        var quizDto = _mapper.Map<QuizDto>(quiz);
        return _responseHandler.Success(quizDto);
    }
}

