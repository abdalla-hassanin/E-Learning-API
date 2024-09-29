namespace ELearningApi.Core.MediatrHandlers.Search.Dtos;

public class LectureDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
    public string CourseName { get; set; }
    public string SectionName { get; set; }
}

