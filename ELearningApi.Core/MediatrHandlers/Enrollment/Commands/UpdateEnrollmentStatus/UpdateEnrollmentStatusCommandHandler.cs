using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Commands.UpdateEnrollmentStatus;

public class UpdateEnrollmentStatusCommandHandler : IRequestHandler<UpdateEnrollmentStatusCommand, ApiResponse<EnrollmentDto>>
{
    private readonly IEnrollmentService _enrollmentService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public UpdateEnrollmentStatusCommandHandler(IEnrollmentService enrollmentService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _enrollmentService = enrollmentService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<EnrollmentDto>> Handle(UpdateEnrollmentStatusCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(request.EnrollmentId, cancellationToken);
            enrollment.Status = request.NewStatus;
            await _enrollmentService.UpdateEnrollmentAsync(enrollment, cancellationToken);
            var enrollmentDto = _mapper.Map<EnrollmentDto>(enrollment);
            return _responseHandler.Success(enrollmentDto, "Enrollment status updated successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            return _responseHandler.NotFound<EnrollmentDto>(ex.Message);
        }
    }
}
