namespace ELearningApi.Core.MediatrHandlers.Section;

public class SectionDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int OrderIndex { get; set; }
    public Guid CourseId { get; set; }
}
