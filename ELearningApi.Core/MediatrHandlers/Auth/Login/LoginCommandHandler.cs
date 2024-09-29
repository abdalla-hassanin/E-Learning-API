using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse<AuthResultDto>>
{
    private readonly IAuthService _authService;
    private readonly ApiResponseHandler _responseHandler;
    private readonly IMapper _mapper;


    public LoginCommandHandler(IAuthService authService, ApiResponseHandler responseHandler, IMapper mapper)
    {
        _authService = authService;
        _responseHandler = responseHandler;
        _mapper = mapper;
    }

    public async Task<ApiResponse<AuthResultDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.LoginAsync(request.Email, request.Password);
        if (result.Succeeded)
        {
            var authResultDto = _mapper.Map<AuthResultDto>(result);
            return _responseHandler.Success(authResultDto, "Login successful.");
        }

        return _responseHandler.Unauthorized<AuthResultDto>(result.Message);
    }
}

