namespace ELearningApi.Data.Entities;
public class Section
{
public Guid Id { get; set; }
public string Title { get; set; }
public string Description { get; set; }
public int OrderIndex { get; set; }
public Guid CourseId { get; set; }
public Course Course { get; set; }
public List<Lecture> Lectures { get; set; } = new List<Lecture>();
public List<Quiz> Quizzes { get; set; } = new List<Quiz>();
}