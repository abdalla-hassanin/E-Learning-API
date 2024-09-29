using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentsForCourse;

public class GetEnrollmentsForCourseQueryHandler : IRequestHandler<GetEnrollmentsForCourseQuery, ApiResponse<IEnumerable<EnrollmentDto>>>
{
    private readonly IEnrollmentService _enrollmentService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetEnrollmentsForCourseQueryHandler(IEnrollmentService enrollmentService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _enrollmentService = enrollmentService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<EnrollmentDto>>> Handle(GetEnrollmentsForCourseQuery request, CancellationToken cancellationToken)
    {
        var enrollments = await _enrollmentService.GetEnrollmentsForCourseAsync(request.CourseId, cancellationToken);
        var enrollmentDtos = _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);
        return _responseHandler.Success(enrollmentDtos);
    }
}
