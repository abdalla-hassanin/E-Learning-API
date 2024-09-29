using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesByLecture;

public class GetQuizzesByLectureQueryHandler : IRequestHandler<GetQuizzesByLectureQuery, ApiResponse<IEnumerable<QuizDto>>>
{
    private readonly IQuizService _quizService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetQuizzesByLectureQueryHandler(IQuizService quizService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _quizService = quizService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<QuizDto>>> Handle(GetQuizzesByLectureQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await _quizService.GetQuizzesByLectureAsync(request.LectureId, cancellationToken);
        var quizDtos = _mapper.Map<IEnumerable<QuizDto>>(quizzes);
        return _responseHandler.Success(quizDtos);
    }
}
