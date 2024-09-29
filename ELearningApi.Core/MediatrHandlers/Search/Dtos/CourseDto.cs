using ELearningApi.Data.Enums;

namespace ELearningApi.Core.MediatrHandlers.Search.Dtos;

public class CourseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public string InstructorName { get; set; }
    public string CategoryName { get; set; }
    public CourseLevel Level { get; set; }
    public TimeSpan EstimatedDuration { get; set; }
}
