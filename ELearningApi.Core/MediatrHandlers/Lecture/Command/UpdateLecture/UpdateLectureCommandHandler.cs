using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.UpdateLecture;

public class UpdateLectureCommandHandler : IRequestHandler<UpdateLectureCommand, ApiResponse<LectureDto>>
{
    private readonly ILectureService _lectureService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public UpdateLectureCommandHandler(ILectureService lectureService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _lectureService = lectureService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<LectureDto>> Handle(UpdateLectureCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingLecture = await _lectureService.GetLectureByIdAsync(request.Id, cancellationToken);
            _mapper.Map(request, existingLecture);
            var updatedLecture = await _lectureService.UpdateLectureAsync(existingLecture, cancellationToken);
            var lectureDto = _mapper.Map<LectureDto>(updatedLecture);
            return _responseHandler.Success(lectureDto, "Lecture updated successfully.");
        }
        catch (KeyNotFoundException)
        {
            return _responseHandler.NotFound<LectureDto>($"Lecture with ID {request.Id} not found.");

        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<LectureDto>($"Failed to update lecture: {ex.Message}");
        }
    }
}
