using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Core.MediatrHandlers.Search.Dtos;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Search.GlobalSearch;

public class GlobalSearchQueryHandler : IRequestHandler<GlobalSearchQuery, ApiResponse<GlobalSearchResultDto>>
{
    private readonly ISearchService _searchService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GlobalSearchQueryHandler(ISearchService searchService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _searchService = searchService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<GlobalSearchResultDto>> Handle(GlobalSearchQuery request, CancellationToken cancellationToken)
    {
        var (courses, instructors, lectures) = await _searchService.PerformGlobalSearchAsync(request.SearchTerm, cancellationToken);
        
        var result = new GlobalSearchResultDto
        {
            Courses = _mapper.Map<IEnumerable<CourseDto>>(courses),
            Instructors = _mapper.Map<IEnumerable<InstructorDto>>(instructors),
            Lectures = _mapper.Map<IEnumerable<LectureDto>>(lectures)
        };

        return _responseHandler.Success(result, "Global search completed successfully.");
    }
}
