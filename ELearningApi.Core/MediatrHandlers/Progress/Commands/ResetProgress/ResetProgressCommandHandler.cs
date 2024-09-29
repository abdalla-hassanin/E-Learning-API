using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Progress.Commands.ResetProgress;

public class ResetProgressCommandHandler : IRequestHandler<ResetProgressCommand, ApiResponse<string>>
{
    private readonly IProgressService _progressService;
    private readonly ApiResponseHandler _responseHandler;

    public ResetProgressCommandHandler(IProgressService progressService, ApiResponseHandler responseHandler)
    {
        _progressService = progressService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(ResetProgressCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _progressService.ResetProgressForEnrollmentAsync(request.EnrollmentId);
            return _responseHandler.Success( "Progress reset successfully.");
        }
        catch (ArgumentException ex)
        {
            return _responseHandler.BadRequest<string>(ex.Message);
        }
        catch (Exception)
        {
            return _responseHandler.UnprocessableEntity<string>("An error occurred while resetting progress.");
        }
    }
    
}