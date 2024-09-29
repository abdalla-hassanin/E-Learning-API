using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Queries.CheckEnrollmentStatus;

public class CheckEnrollmentStatusQueryHandler : IRequestHandler<CheckEnrollmentStatusQuery, ApiResponse<string>>
{
    private readonly IEnrollmentService _enrollmentService;
    private readonly ApiResponseHandler _responseHandler;

    public CheckEnrollmentStatusQueryHandler(IEnrollmentService enrollmentService, ApiResponseHandler responseHandler)
    {
        _enrollmentService = enrollmentService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(CheckEnrollmentStatusQuery request, CancellationToken cancellationToken)
    {
        var isEnrolled = await _enrollmentService.CheckEnrollmentStatusAsync(request.StudentId, request.CourseId, cancellationToken);
        return _responseHandler.Success(isEnrolled.ToString());
    }
}
