using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.SearchCourses;

public class SearchCoursesQueryHandler : IRequestHandler<SearchCoursesQuery, ApiResponse<SearchCoursesResult>>
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public SearchCoursesQueryHandler(ICourseService courseService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _courseService = courseService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<SearchCoursesResult>> Handle(SearchCoursesQuery request, CancellationToken cancellationToken)
    {
        var (courses, totalCount) = await _courseService.SearchCoursesAsync(
            request.SearchTerm,
            request.PageNumber,
            request.PageSize,
            request.Level,
            request.CategoryId,
            cancellationToken
        );

        var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
        var result = new SearchCoursesResult
        {
            Courses = courseDtos,
            TotalCount = totalCount
        };
        return _responseHandler.Success(result);
    }
}