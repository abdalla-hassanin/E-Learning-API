
using ELearningApi.Data.Enums;

namespace ELearningApi.Data.Entities;

public class LectureResource
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public ResourceType Type { get; set; }
    public Guid LectureId { get; set; }
    public Lecture Lecture { get; set; }
}
