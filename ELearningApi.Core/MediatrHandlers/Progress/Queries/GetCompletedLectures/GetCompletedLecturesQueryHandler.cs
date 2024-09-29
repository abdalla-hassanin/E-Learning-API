using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Queries.GetCompletedLectures;

public class GetCompletedLecturesQueryHandler : IRequestHandler<GetCompletedLecturesQuery, ApiResponse<IEnumerable<ProgressDto>>>
{
    private readonly IProgressService _progressService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetCompletedLecturesQueryHandler(IProgressService progressService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _progressService = progressService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<ProgressDto>>> Handle(GetCompletedLecturesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var completedLectures = await _progressService.GetCompletedLecturesAsync(request.StudentId, request.CourseId);
            var completedProgressDtos = _mapper.Map<IEnumerable<ProgressDto>>(completedLectures);
            return _responseHandler.Success(completedProgressDtos);
        }
        catch (ArgumentException ex)
        {
            return _responseHandler.NotFound<IEnumerable<ProgressDto>>(ex.Message);
        }
    }
}