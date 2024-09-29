using ELearningApi.Data.Enums;

namespace ELearningApi.Core.MediatrHandlers.Lecture;

public class LectureResourceDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public ResourceType Type { get; set; }
}
