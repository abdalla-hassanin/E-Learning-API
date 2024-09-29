using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Commands.UpdateProgress;

public class UpdateProgressCommandHandler : IRequestHandler<UpdateProgressCommand, ApiResponse<ProgressDto>>
{
    private readonly IProgressService _progressService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public UpdateProgressCommandHandler(IProgressService progressService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _progressService = progressService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<ProgressDto>> Handle(UpdateProgressCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var progress = await _progressService.UpdateProgressAsync(
                request.EnrollmentId,
                request.LectureId,
                request.ProgressPercentage,
                request.Status
            );

            var progressDto = _mapper.Map<ProgressDto>(progress);
            return _responseHandler.Success(progressDto, "Progress updated successfully.");
        }
        catch (ArgumentException ex)
        {
            return _responseHandler.BadRequest<ProgressDto>(ex.Message);
        }
        catch (Exception)
        {
            return _responseHandler.UnprocessableEntity<ProgressDto>("An error occurred while updating progress.");
        }
    }
}
