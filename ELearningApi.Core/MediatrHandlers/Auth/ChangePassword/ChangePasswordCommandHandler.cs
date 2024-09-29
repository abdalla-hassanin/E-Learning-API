using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ApiResponse<string>>
{
    private readonly IAuthService _authService;
    private readonly ApiResponseHandler _responseHandler;

    public ChangePasswordCommandHandler(IAuthService authService, ApiResponseHandler responseHandler)
    {
        _authService = authService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.ChangePasswordAsync(request.Username, request.CurrentPassword, request.NewPassword);
        return result.Succeeded
            ? _responseHandler.Success( "Password changed successfully.")
            : _responseHandler.BadRequest<string>(result.Message);
    }
}
