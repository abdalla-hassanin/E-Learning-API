using ELearningApi.Data.Entities;

namespace ELearningApi.Service.IService;

public interface IEnrollmentService
{
    Task<Enrollment> EnrollStudentInCourseAsync(Guid studentId, Guid courseId,
        CancellationToken cancellationToken = default);

    Task UnEnrollStudentFromCourseAsync(Guid studentId, Guid courseId, CancellationToken cancellationToken = default);
    Task<Enrollment> GetEnrollmentByIdAsync(Guid enrollmentId, CancellationToken cancellationToken = default);

    Task<IEnumerable<Enrollment>> GetEnrollmentsForCourseAsync(Guid courseId,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<Enrollment>> GetEnrollmentsForStudentAsync(Guid studentId,
        CancellationToken cancellationToken = default);

    Task<bool> CheckEnrollmentStatusAsync(Guid studentId, Guid courseId, CancellationToken cancellationToken = default);
    Task<Enrollment> UpdateEnrollmentAsync(Enrollment enrollment, CancellationToken cancellationToken = default);

}