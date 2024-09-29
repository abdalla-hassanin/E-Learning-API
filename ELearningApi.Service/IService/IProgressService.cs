using ELearningApi.Data.Entities;
using ELearningApi.Data.Enums;

namespace ELearningApi.Service.IService;

public interface IProgressService
{
    Task<Progress> UpdateProgressAsync(Guid enrollmentId, Guid lectureId, decimal progressPercentage, ProgressStatus status);
    Task<decimal> GetProgressForEnrollmentAsync(Guid enrollmentId);
    Task<decimal> GetOverallCourseProgressAsync(Guid studentId, Guid courseId);
    Task<Progress> MarkLectureAsCompleteAsync(Guid enrollmentId, Guid lectureId);
    Task<IEnumerable<Lecture>> GetCompletedLecturesAsync(Guid studentId, Guid courseId);
    Task<IEnumerable<Progress>> GetProgressDetailsForEnrollmentAsync(Guid enrollmentId);
    Task<bool> IsLectureCompletedAsync(Guid enrollmentId, Guid lectureId);
    Task ResetProgressForEnrollmentAsync(Guid enrollmentId);
}
