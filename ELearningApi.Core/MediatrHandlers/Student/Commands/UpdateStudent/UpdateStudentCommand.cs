using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Student.Commands.UpdateStudent;

public class UpdateStudentCommand : IRequest<ApiResponse<StudentDto>>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    // Add other properties as needed
}
