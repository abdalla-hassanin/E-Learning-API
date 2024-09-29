using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.Base;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.RegisterInstructor;

public class RegisterInstructorCommand : IRequest<ApiResponse<AuthResultDto>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Expertise { get; set; }
    public string Biography { get; set; }
}
