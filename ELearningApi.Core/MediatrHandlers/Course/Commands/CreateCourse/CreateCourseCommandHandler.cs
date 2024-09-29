using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Commands.CreateCourse;
public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, ApiResponse<CourseDto>>
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public CreateCourseCommandHandler(ICourseService courseService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _courseService = courseService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<CourseDto>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = _mapper.Map<Data.Entities.Course>(request);
        var createdCourse = await _courseService.CreateCourseAsync(course, cancellationToken);
        var courseDto = _mapper.Map<CourseDto>(createdCourse);
        return _responseHandler.Created(courseDto);
    }
}
