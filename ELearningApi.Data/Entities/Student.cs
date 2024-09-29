namespace ELearningApi.Data.Entities;

public class Student 
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
