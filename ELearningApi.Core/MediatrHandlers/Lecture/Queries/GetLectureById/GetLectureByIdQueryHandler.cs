using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Queries.GetLectureById;

public class GetLectureByIdQueryHandler : IRequestHandler<GetLectureByIdQuery, ApiResponse<LectureDto>>
{
    private readonly ILectureService _lectureService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetLectureByIdQueryHandler(ILectureService lectureService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _lectureService = lectureService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<LectureDto>> Handle(GetLectureByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var lecture = await _lectureService.GetLectureByIdAsync(request.Id, cancellationToken);
            var lectureDto = _mapper.Map<LectureDto>(lecture);
            return _responseHandler.Success(lectureDto, "Lecture retrieved successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            return _responseHandler.NotFound<LectureDto>(ex.Message);
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<LectureDto>($"Error retrieving lecture: {ex.Message}");
        }
    }
}
