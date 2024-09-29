using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Entities;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.AddResourceToLecture;

public class AddResourceToLectureCommandHandler : IRequestHandler<AddResourceToLectureCommand, ApiResponse<LectureDto>>
{
    private readonly ILectureService _lectureService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public AddResourceToLectureCommandHandler(ILectureService lectureService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _lectureService = lectureService ?? throw new ArgumentNullException(nameof(lectureService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _responseHandler = responseHandler ?? throw new ArgumentNullException(nameof(responseHandler));
    }

    public async Task<ApiResponse<LectureDto>> Handle(AddResourceToLectureCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var resource = _mapper.Map<LectureResource>(request);
            var updatedLecture = await _lectureService.AddResourceToLectureAsync(request.LectureId, resource, cancellationToken);
            var lectureDto = _mapper.Map<LectureDto>(updatedLecture);
            return _responseHandler.Success(lectureDto, "Resource added to lecture successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            return _responseHandler.NotFound<LectureDto>(ex.Message);
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<LectureDto>($"Failed to add resource to lecture: {ex.Message}");
        }
    }
}
