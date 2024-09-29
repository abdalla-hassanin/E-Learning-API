using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Commands.UpdateCourse;

public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, ApiResponse<CourseDto>>
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public UpdateCourseCommandHandler(ICourseService courseService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _courseService = courseService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<CourseDto>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingCourse = await _courseService.GetCourseByIdAsync(request.Id, cancellationToken);
            _mapper.Map(request, existingCourse);
            var updatedCourse = await _courseService.UpdateCourseAsync(existingCourse, cancellationToken);
            var courseDto = _mapper.Map<CourseDto>(updatedCourse);
            return _responseHandler.Success(courseDto, "Course updated successfully.");
        }
        catch (KeyNotFoundException)
        {
            return _responseHandler.NotFound<CourseDto>($"Course with ID {request.Id} not found.");
        }
    }
}