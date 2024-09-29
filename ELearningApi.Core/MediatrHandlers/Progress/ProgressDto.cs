using ELearningApi.Data.Enums;

namespace ELearningApi.Core.MediatrHandlers.Progress;

public class ProgressDto
{
    public Guid Id { get; set; }
    public Guid EnrollmentId { get; set; }
    public Guid LectureId { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public ProgressStatus Status { get; set; }
    public decimal ProgressPercentage { get; set; }
}
