using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Commands.EnrollStudentInCourse;

public class EnrollStudentInCourseCommandHandler : IRequestHandler<EnrollStudentInCourseCommand, ApiResponse<EnrollmentDto>>
{
    private readonly IEnrollmentService _enrollmentService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public EnrollStudentInCourseCommandHandler(IEnrollmentService enrollmentService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _enrollmentService = enrollmentService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<EnrollmentDto>> Handle(EnrollStudentInCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var enrollment = await _enrollmentService.EnrollStudentInCourseAsync(request.StudentId, request.CourseId, cancellationToken);
            var enrollmentDto = _mapper.Map<EnrollmentDto>(enrollment);
            return _responseHandler.Success(enrollmentDto, "Student enrolled successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            return _responseHandler.NotFound<EnrollmentDto>(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return _responseHandler.BadRequest<EnrollmentDto>(ex.Message);
        }
    }
}
