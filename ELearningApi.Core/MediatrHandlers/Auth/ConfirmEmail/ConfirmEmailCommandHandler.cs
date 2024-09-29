using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.ConfirmEmail;

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, ApiResponse<string>>
{
    private readonly IAuthService _authService;
    private readonly ApiResponseHandler _responseHandler;

    public ConfirmEmailCommandHandler(IAuthService authService, ApiResponseHandler responseHandler)
    {
        _authService = authService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.ConfirmEmailAsync(request.UserId, request.Token);
        return result.Succeeded
            ? _responseHandler.Success( "Email confirmed successfully.")
            : _responseHandler.BadRequest<string>(result.Message);
    }
}
