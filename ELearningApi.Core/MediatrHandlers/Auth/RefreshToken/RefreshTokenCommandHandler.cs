using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ApiResponse<AuthResultDto>>
{
    private readonly IAuthService _authService;
    private readonly ApiResponseHandler _responseHandler;
    private readonly IMapper _mapper;

    public RefreshTokenCommandHandler(IAuthService authService, ApiResponseHandler responseHandler, IMapper mapper)
    {
        _authService = authService;
        _responseHandler = responseHandler;
        _mapper = mapper;
    }

    public async Task<ApiResponse<AuthResultDto>> Handle(RefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _authService.RefreshTokenAsync(request.AccessToken, request.RefreshToken);
        if (result.Succeeded)
        {
            var authResultDto = _mapper.Map<AuthResultDto>(result);
            return _responseHandler.Success(authResultDto, "Token refreshed successfully.");
        }

        return _responseHandler.Unauthorized<AuthResultDto>(result.Message);
    }
}