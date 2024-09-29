using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Queries.GetLecturesForSection;

public class GetLecturesForSectionQueryHandler : IRequestHandler<GetLecturesForSectionQuery, ApiResponse<IEnumerable<LectureDto>>>
{
    private readonly ILectureService _lectureService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetLecturesForSectionQueryHandler(ILectureService lectureService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _lectureService = lectureService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<LectureDto>>> Handle(GetLecturesForSectionQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var lectures = await _lectureService.GetLecturesForSectionAsync(request.SectionId, cancellationToken);
            var lectureDtos = _mapper.Map<IEnumerable<LectureDto>>(lectures);
            return _responseHandler.Success(lectureDtos, "Lectures retrieved successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            return _responseHandler.NotFound<IEnumerable<LectureDto>>(ex.Message);
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<IEnumerable<LectureDto>>($"Error retrieving lectures: {ex.Message}");
        }
    }
}
