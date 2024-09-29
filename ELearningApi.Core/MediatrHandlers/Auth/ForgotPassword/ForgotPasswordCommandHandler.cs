using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ApiResponse<string>>
{
    private readonly IAuthService _authService;
    private readonly ApiResponseHandler _responseHandler;

    public ForgotPasswordCommandHandler(IAuthService authService, ApiResponseHandler responseHandler)
    {
        _authService = authService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.ForgotPasswordAsync(request.Email);
        return _responseHandler.Success( result.Message);
    }
}
