using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.ResetPassword;

public class ResetPasswordCommand : IRequest<ApiResponse<string>>
{
    public string Email { get; set; }
    public string Token { get; set; }
    public string NewPassword { get; set; }
}
