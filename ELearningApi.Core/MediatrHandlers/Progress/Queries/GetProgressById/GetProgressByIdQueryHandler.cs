using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Queries.GetProgressById;

public class GetProgressByIdQueryHandler : IRequestHandler<GetProgressByIdQuery, ApiResponse<ProgressDto>>
{
    private readonly IProgressService _progressService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetProgressByIdQueryHandler(IProgressService progressService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _progressService = progressService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<ProgressDto>> Handle(GetProgressByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var progress = await _progressService.GetProgressDetailsForEnrollmentAsync(request.Id);

            var progressDto = _mapper.Map<ProgressDto>(progress);
            return _responseHandler.Success(progressDto);

        }
        catch (KeyNotFoundException)
        {
            return _responseHandler.NotFound<ProgressDto>("Progress not found.");
        }
    }
}