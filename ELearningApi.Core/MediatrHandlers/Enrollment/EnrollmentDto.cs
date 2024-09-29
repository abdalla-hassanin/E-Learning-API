using ELearningApi.Data.Enums;

namespace ELearningApi.Core.MediatrHandlers.Enrollment;

public class EnrollmentDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public DateTime EnrolledAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public EnrollmentStatus Status { get; set; }
    public decimal Progress { get; set; }
}
