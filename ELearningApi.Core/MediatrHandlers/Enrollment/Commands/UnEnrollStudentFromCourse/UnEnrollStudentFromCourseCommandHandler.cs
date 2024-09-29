using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Commands.UnEnrollStudentFromCourse;

public class UnEnrollStudentFromCourseCommandHandler : IRequestHandler<UnEnrollStudentFromCourseCommand, ApiResponse<string>>
{
    private readonly IEnrollmentService _enrollmentService;
    private readonly ApiResponseHandler _responseHandler;

    public UnEnrollStudentFromCourseCommandHandler(IEnrollmentService enrollmentService, ApiResponseHandler responseHandler)
    {
        _enrollmentService = enrollmentService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(UnEnrollStudentFromCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _enrollmentService.UnEnrollStudentFromCourseAsync(request.StudentId, request.CourseId, cancellationToken);
            return _responseHandler.Success( "Student unEnrolled successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            return _responseHandler.NotFound<string>(ex.Message);
        }
    }
}
