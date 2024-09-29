using ELearningApi.Data.Enums;

namespace ELearningApi.Data.Entities;

public class Lecture
{
public Guid Id { get; set; }
public string Title { get; set; }
public string Description { get; set; }
public string Content { get; set; }
public TimeSpan Duration { get; set; }
public int OrderIndex { get; set; }
public Guid SectionId { get; set; }
public Section Section { get; set; }
public List<Progress> Progresses { get; set; } = new List<Progress>();
public List<LectureResource> Resources { get; set; } = new List<LectureResource>();
public LectureType Type { get; set; }
public string VideoUrl { get; set; }
}
