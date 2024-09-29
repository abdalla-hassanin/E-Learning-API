using ELearningApi.Data.Enums;

namespace ELearningApi.Data.Entities;

public class Course
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Guid InstructorId { get; set; }
    public Instructor Instructor { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public List<Section> Sections { get; set; } = new List<Section>();
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public List<Review> Reviews { get; set; } = new List<Review>();
    public string ThumbnailUrl { get; set; }
    public string TrailerVideoUrl { get; set; }
    public CourseLevel Level { get; set; }
    public List<string> Prerequisites { get; set; } = new List<string>();
    public List<string> LearningObjectives { get; set; } = new List<string>();
    public TimeSpan EstimatedDuration { get; set; }
    public DateTime? PublishedAt { get; set; }
}