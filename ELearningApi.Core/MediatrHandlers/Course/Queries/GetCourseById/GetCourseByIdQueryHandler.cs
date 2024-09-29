using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.GetCourseById;

public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, ApiResponse<CourseDto>>
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetCourseByIdQueryHandler(ICourseService courseService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _courseService = courseService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var course = await _courseService.GetCourseByIdAsync(request.Id, cancellationToken);
            var courseDto = _mapper.Map<CourseDto>(course);
            return _responseHandler.Success(courseDto);
        }
        catch (KeyNotFoundException)
        {
            return _responseHandler.NotFound<CourseDto>("Course not found");
        }
    }
}