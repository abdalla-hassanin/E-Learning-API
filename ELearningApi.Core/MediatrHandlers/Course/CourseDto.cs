using ELearningApi.Data.Enums;

namespace ELearningApi.Core.MediatrHandlers.Course;

public class CourseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public Guid InstructorId { get; set; }
    public Guid CategoryId { get; set; }
    public string ThumbnailUrl { get; set; }
    public string TrailerVideoUrl { get; set; }
    public CourseLevel Level { get; set; }
    public List<string> Prerequisites { get; set; }
    public List<string> LearningObjectives { get; set; }
    public TimeSpan EstimatedDuration { get; set; }
    public DateTime? PublishedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
