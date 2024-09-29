namespace ELearningApi.Data.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();
}
