using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.RevokeToken;

public class RevokeTokenCommand : IRequest<ApiResponse<string>>
{
    public string Username { get; set; }
}
