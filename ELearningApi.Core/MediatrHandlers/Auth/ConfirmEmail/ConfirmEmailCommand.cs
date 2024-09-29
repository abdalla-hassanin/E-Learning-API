using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.ConfirmEmail;

public class ConfirmEmailCommand : IRequest<ApiResponse<string>>
{
    public string UserId { get; set; }
    public string Token { get; set; }
    
}
