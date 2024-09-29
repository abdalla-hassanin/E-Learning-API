using ELearningApi.Data.Enums;

namespace ELearningApi.Data.Entities;

public class Progress
{
public Guid Id { get; set; }
public Guid EnrollmentId { get; set; }
public Enrollment Enrollment { get; set; }
public Guid LectureId { get; set; }
public Lecture Lecture { get; set; }
public DateTime? StartedAt { get; set; }
public DateTime? CompletedAt { get; set; }
public ProgressStatus Status { get; set; }
public decimal ProgressPercentage { get; set; }
}