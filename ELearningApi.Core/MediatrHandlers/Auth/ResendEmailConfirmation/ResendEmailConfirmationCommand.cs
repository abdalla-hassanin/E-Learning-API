using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.ResendEmailConfirmation;

public class ResendEmailConfirmationCommand : IRequest<ApiResponse<string>>
{
    public string Email { get; set; }
}
