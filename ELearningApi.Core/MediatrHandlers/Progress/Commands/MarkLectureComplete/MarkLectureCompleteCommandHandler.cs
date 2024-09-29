using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Commands.MarkLectureComplete;

public class MarkLectureCompleteCommandHandler : IRequestHandler<MarkLectureCompleteCommand, ApiResponse<ProgressDto>>
{
    private readonly IProgressService _progressService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public MarkLectureCompleteCommandHandler(IProgressService progressService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _progressService = progressService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<ProgressDto>> Handle(MarkLectureCompleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var progress = await _progressService.MarkLectureAsCompleteAsync(request.EnrollmentId, request.LectureId);
            var progressDto = _mapper.Map<ProgressDto>(progress);
            return _responseHandler.Success(progressDto, "Lecture marked as complete.");
        }
        catch (ArgumentException ex)
        {
            return _responseHandler.BadRequest<ProgressDto>(ex.Message);
        }
        catch (Exception)
        {
            return _responseHandler.UnprocessableEntity<ProgressDto>("An error occurred while marking the lecture as complete.");
        }
    }
}
