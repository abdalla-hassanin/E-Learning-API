using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Queries.GetProgressForEnrollment;

public class GetProgressForEnrollmentQueryHandler : IRequestHandler<GetProgressForEnrollmentQuery, ApiResponse<IEnumerable<ProgressDto>>>
{
    private readonly IProgressService _progressService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetProgressForEnrollmentQueryHandler(IProgressService progressService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _progressService = progressService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<ProgressDto>>> Handle(GetProgressForEnrollmentQuery request, CancellationToken cancellationToken)
    {
        var progresses = await _progressService.GetProgressDetailsForEnrollmentAsync(request.EnrollmentId);
        var progressDtos = _mapper.Map<IEnumerable<ProgressDto>>(progresses);
        return _responseHandler.Success(progressDtos);
    }
}

