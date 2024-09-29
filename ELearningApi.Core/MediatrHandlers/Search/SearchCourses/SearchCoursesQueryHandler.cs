using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Core.MediatrHandlers.Search.Dtos;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Search.SearchCourses;

public class SearchCoursesQueryHandler : IRequestHandler<SearchCoursesQuery, ApiResponse<IEnumerable<CourseDto>>>
{
    private readonly ISearchService _searchService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public SearchCoursesQueryHandler(ISearchService searchService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _searchService = searchService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<CourseDto>>> Handle(SearchCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await _searchService.SearchCoursesAsync(request.SearchTerm, request.Level, request.CategoryId, request.MinPrice, request.MaxPrice, cancellationToken);
        var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
        return _responseHandler.Success(courseDtos, "Courses retrieved successfully.");
    }
}
