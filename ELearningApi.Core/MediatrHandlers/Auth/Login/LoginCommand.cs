using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.Login;

public class LoginCommand : IRequest<ApiResponse<AuthResultDto>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
