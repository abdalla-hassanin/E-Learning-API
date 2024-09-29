namespace ELearningApi.Data.Entities;

public class Instructor
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public string Expertise { get; set; }
    public string Biography { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();
}
