using ELearningApi.Data.Enums;

namespace ELearningApi.Core.MediatrHandlers.Lecture;

public class LectureDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public TimeSpan Duration { get; set; }
    public int OrderIndex { get; set; }
    public Guid SectionId { get; set; }
    public LectureType Type { get; set; }
    public string VideoUrl { get; set; }
    public List<LectureResourceDto> Resources { get; set; }
}
