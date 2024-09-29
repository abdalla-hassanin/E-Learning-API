using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.ChangePassword;

public class ChangePasswordCommand : IRequest<ApiResponse<string>>
{
    public string Username { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
