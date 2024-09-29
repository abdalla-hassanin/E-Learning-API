using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.ResendEmailConfirmation;

public class ResendEmailConfirmationCommandHandler : IRequestHandler<ResendEmailConfirmationCommand, ApiResponse<string>>
{
    private readonly IAuthService _authService;
    private readonly ApiResponseHandler _responseHandler;

    public ResendEmailConfirmationCommandHandler(IAuthService authService, ApiResponseHandler responseHandler)
    {
        _authService = authService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(ResendEmailConfirmationCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.ResendEmailConfirmationAsync(request.Email);
        return _responseHandler.Success( result.Message);
    }
}

