using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.CreateLecture;

public class CreateLectureCommandHandler : IRequestHandler<CreateLectureCommand, ApiResponse<LectureDto>>
{
    private readonly ILectureService _lectureService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public CreateLectureCommandHandler(ILectureService lectureService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _lectureService = lectureService ?? throw new ArgumentNullException(nameof(lectureService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _responseHandler = responseHandler ?? throw new ArgumentNullException(nameof(responseHandler));
    }

    public async Task<ApiResponse<LectureDto>> Handle(CreateLectureCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var lecture = _mapper.Map<Data.Entities.Lecture>(request);
            var createdLecture = await _lectureService.CreateLectureAsync(lecture, cancellationToken);
            var lectureDto = _mapper.Map<LectureDto>(createdLecture);
            return _responseHandler.Success(lectureDto, "Lecture created successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<LectureDto>($"Failed to create lecture: {ex.Message}");
        }
    }
}
