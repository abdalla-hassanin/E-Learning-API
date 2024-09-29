using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.RefreshToken;

public class RefreshTokenCommand : IRequest<ApiResponse<AuthResultDto>>
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
