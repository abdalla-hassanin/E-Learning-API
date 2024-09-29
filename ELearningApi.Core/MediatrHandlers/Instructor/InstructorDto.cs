namespace ELearningApi.Core.MediatrHandlers.Instructor;

public class InstructorDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Expertise { get; set; }
    public string Biography { get; set; }
    // Add other properties as needed
}
