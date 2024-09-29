using ELearningApi.Data.Enums;

namespace ELearningApi.Data.Entities;

public class Enrollment
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public DateTime EnrolledAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public EnrollmentStatus Status { get; set; }
    public decimal Progress { get; set; }
    public List<Progress> Progresses { get; set; } = new List<Progress>();
}