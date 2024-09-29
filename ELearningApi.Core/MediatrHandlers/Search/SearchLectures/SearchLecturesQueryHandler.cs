using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Core.MediatrHandlers.Search.Dtos;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Search.SearchLectures;

public class SearchLecturesQueryHandler : IRequestHandler<SearchLecturesQuery, ApiResponse<IEnumerable<LectureDto>>>
{
    private readonly ISearchService _searchService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public SearchLecturesQueryHandler(ISearchService searchService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _searchService = searchService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<LectureDto>>> Handle(SearchLecturesQuery request, CancellationToken cancellationToken)
    {
        var lectures = await _searchService.SearchLecturesAsync(request.SearchTerm, request.CourseId, cancellationToken);
        var lectureDtos = _mapper.Map<IEnumerable<LectureDto>>(lectures);
        return _responseHandler.Success(lectureDtos, "Lectures retrieved successfully.");
    }
}
