using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.RemoveResourceFromLecture;

public class RemoveResourceFromLectureCommandHandler : IRequestHandler<RemoveResourceFromLectureCommand, ApiResponse<LectureDto>>
{
    private readonly ILectureService _lectureService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public RemoveResourceFromLectureCommandHandler(ILectureService lectureService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _lectureService = lectureService ?? throw new ArgumentNullException(nameof(lectureService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _responseHandler = responseHandler ?? throw new ArgumentNullException(nameof(responseHandler));
    }

    public async Task<ApiResponse<LectureDto>> Handle(RemoveResourceFromLectureCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var updatedLecture = await _lectureService.RemoveResourceFromLectureAsync(request.LectureId, request.ResourceId, cancellationToken);
            var lectureDto = _mapper.Map<LectureDto>(updatedLecture);
            return _responseHandler.Success(lectureDto, "Resource removed from lecture successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            return _responseHandler.NotFound<LectureDto>(ex.Message);
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<LectureDto>($"Failed to remove resource from lecture: {ex.Message}");
        }
    }
}
