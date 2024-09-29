using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Instructor.Commands.UpdateInstructor;

public class UpdateInstructorCommand : IRequest<ApiResponse<InstructorDto>>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Expertise { get; set; }
    public string Biography { get; set; }
    // Add other properties as needed
}
