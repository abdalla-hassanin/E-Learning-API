using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentById;
public class GetEnrollmentByIdQueryHandler : IRequestHandler<GetEnrollmentByIdQuery, ApiResponse<EnrollmentDto>>
{
    private readonly IEnrollmentService _enrollmentService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetEnrollmentByIdQueryHandler(IEnrollmentService enrollmentService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _enrollmentService = enrollmentService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<EnrollmentDto>> Handle(GetEnrollmentByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(request.EnrollmentId, cancellationToken);
            var enrollmentDto = _mapper.Map<EnrollmentDto>(enrollment);
            return _responseHandler.Success(enrollmentDto);
        }
        catch (KeyNotFoundException ex)
        {
            return _responseHandler.NotFound<EnrollmentDto>(ex.Message);
        }
    }
}