using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.GetCoursesByInstructor;
public class GetCoursesByInstructorQueryHandler : IRequestHandler<GetCoursesByInstructorQuery, ApiResponse<IEnumerable<CourseDto>>>
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetCoursesByInstructorQueryHandler(ICourseService courseService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _courseService = courseService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<CourseDto>>> Handle(GetCoursesByInstructorQuery request, CancellationToken cancellationToken)
    {
        var courses = await _courseService.GetCoursesByInstructorAsync(request.InstructorId, cancellationToken);
        var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
        return _responseHandler.Success(courseDtos);
    }
}