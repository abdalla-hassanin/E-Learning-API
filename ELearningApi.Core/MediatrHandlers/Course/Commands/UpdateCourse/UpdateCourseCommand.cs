using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Enums;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Commands.UpdateCourse;
public class UpdateCourseCommand : IRequest<ApiResponse<CourseDto>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public string ThumbnailUrl { get; set; }
    public string TrailerVideoUrl { get; set; }
    public CourseLevel Level { get; set; }
    public List<string> Prerequisites { get; set; }
    public List<string> LearningObjectives { get; set; }
    public TimeSpan EstimatedDuration { get; set; }
}
