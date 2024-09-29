using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.ForgotPassword;

public class ForgotPasswordCommand : IRequest<ApiResponse<string>>
{
    public string Email { get; set; }
}
