using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesBySection;

public class GetQuizzesBySectionQueryHandler : IRequestHandler<GetQuizzesBySectionQuery, ApiResponse<IEnumerable<QuizDto>>>
{
    private readonly IQuizService _quizService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetQuizzesBySectionQueryHandler(IQuizService quizService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizService = quizService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<QuizDto>>> Handle(GetQuizzesBySectionQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await _quizService.GetQuizzesBySectionAsync(request.SectionId, cancellationToken);
        var quizDtos = _mapper.Map<IEnumerable<QuizDto>>(quizzes);
        return _responseHandler.Success(quizDtos);
    }
}
