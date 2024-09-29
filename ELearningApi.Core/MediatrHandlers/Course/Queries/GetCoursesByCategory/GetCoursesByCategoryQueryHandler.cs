using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.GetCoursesByCategory;

public class GetCoursesByCategoryQueryHandler : IRequestHandler<GetCoursesByCategoryQuery, ApiResponse<IEnumerable<CourseDto>>>
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetCoursesByCategoryQueryHandler(ICourseService courseService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _courseService = courseService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<CourseDto>>> Handle(GetCoursesByCategoryQuery request, CancellationToken cancellationToken)
    {
        var courses = await _courseService.GetCoursesByCategoryAsync(request.CategoryId, cancellationToken);
        var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
        return _responseHandler.Success(courseDtos);
    }
}