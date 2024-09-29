using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesByCourse;

public class GetQuizzesByCourseQueryHandler : IRequestHandler<GetQuizzesByCourseQuery, ApiResponse<IEnumerable<QuizDto>>>
{
    private readonly IQuizService _quizService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetQuizzesByCourseQueryHandler(IQuizService quizService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizService = quizService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<QuizDto>>> Handle(GetQuizzesByCourseQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await _quizService.GetQuizzesByCourseAsync(request.CourseId, cancellationToken);
        var quizDtos = _mapper.Map<IEnumerable<QuizDto>>(quizzes);
        return _responseHandler.Success(quizDtos);
    }
}
