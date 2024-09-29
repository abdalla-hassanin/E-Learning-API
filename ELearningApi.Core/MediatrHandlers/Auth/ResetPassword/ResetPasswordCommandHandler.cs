using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.ResetPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ApiResponse<string>>
{
    private readonly IAuthService _authService;
    private readonly ApiResponseHandler _responseHandler;

    public ResetPasswordCommandHandler(IAuthService authService, ApiResponseHandler responseHandler)
    {
        _authService = authService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.ResetPasswordAsync(request.Email, request.Token, request.NewPassword);
        return result.Succeeded
            ? _responseHandler.Success( "Password reset successfully.")
            : _responseHandler.BadRequest<string>(result.Message);
    }
}
