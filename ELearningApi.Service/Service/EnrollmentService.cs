using ELearningApi.Data.Entities;
using ELearningApi.Data.Enums;
using ELearningApi.Infrustructure.Base;
using ELearningApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace ELearningApi.Service.Service;

public class EnrollmentService : IEnrollmentService
{
    private readonly IUnitOfWork _unitOfWork;

    public EnrollmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Enrollment> EnrollStudentInCourseAsync(Guid studentId, Guid courseId,
        CancellationToken cancellationToken = default)
    {
        var student =
            (await _unitOfWork.Repository<Student>()
                .FindAsync(s => s.Id == studentId, cancellationToken: cancellationToken)).FirstOrDefault();
        if (student == null)
            throw new KeyNotFoundException($"Student with ID {studentId} not found.");

        var course =
            (await _unitOfWork.Repository<Course>()
                .FindAsync(c => c.Id == courseId, cancellationToken: cancellationToken)).FirstOrDefault();
        if (course == null)
            throw new KeyNotFoundException($"Course with ID {courseId} not found.");

        var existingEnrollment = await CheckEnrollmentStatusAsync(studentId, courseId, cancellationToken);
        if (existingEnrollment)
            throw new InvalidOperationException($"Student {studentId} is already enrolled in course {courseId}.");

        var enrollment = new Enrollment
        {
            StudentId = studentId,
            CourseId = courseId,
            EnrolledAt = DateTime.UtcNow,
            Status = EnrollmentStatus.Enrolled
        };

        await _unitOfWork.Repository<Enrollment>().AddAsync(enrollment, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return enrollment;
    }

    public async Task UnEnrollStudentFromCourseAsync(Guid studentId, Guid courseId,
        CancellationToken cancellationToken = default)
    {
        var enrollment = (await _unitOfWork.Repository<Enrollment>()
                .FindAsync(e => e.StudentId == studentId && e.CourseId == courseId,
                    cancellationToken: cancellationToken))
            .FirstOrDefault();

        if (enrollment == null)
            throw new KeyNotFoundException($"Enrollment for student {studentId} in course {courseId} not found.");

        await _unitOfWork.Repository<Enrollment>().RemoveAsync(enrollment, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
    }

    public async Task<Enrollment> GetEnrollmentByIdAsync(Guid enrollmentId,
        CancellationToken cancellationToken = default)
    {
        var enrollment = (await _unitOfWork.Repository<Enrollment>()
                .FindAsync(
                    e => e.Id == enrollmentId,
                    cancellationToken: cancellationToken
                ))
            .FirstOrDefault();

        if (enrollment == null)
            throw new KeyNotFoundException($"Enrollment with ID {enrollmentId} not found.");

        return enrollment;
    }

    public async Task<IEnumerable<Enrollment>> GetEnrollmentsForCourseAsync(Guid courseId,
        CancellationToken cancellationToken = default)
    {
        var enrollments = await _unitOfWork.Repository<Enrollment>()
            .FindAsync(
                e => e.CourseId == courseId,
                include: q => q.Include(e => e.Student),
                cancellationToken: cancellationToken
            );

        return enrollments;
    }

    public async Task<IEnumerable<Enrollment>> GetEnrollmentsForStudentAsync(Guid studentId,
        CancellationToken cancellationToken = default)
    {
        var enrollments = await _unitOfWork.Repository<Enrollment>()
            .FindAsync(
                e => e.StudentId == studentId,
                include: q => q.Include(e => e.Course),
                cancellationToken: cancellationToken
            );

        return enrollments;
    }

    public async Task<bool> CheckEnrollmentStatusAsync(Guid studentId, Guid courseId,
        CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.Repository<Enrollment>()
            .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId, cancellationToken);
    }

    public async Task<Enrollment> UpdateEnrollmentAsync(Enrollment enrollment,
        CancellationToken cancellationToken = default)
    {
        var existingEnrollments = await _unitOfWork.Repository<Enrollment>().FindAsync(
            e => e.Id == enrollment.Id,
            cancellationToken: cancellationToken
        );
        var existingEnrollment = existingEnrollments.FirstOrDefault();
        if (existingEnrollment == null)
            throw new KeyNotFoundException($"Enrollment with ID {enrollment.Id} not found.");

        // Update properties
        existingEnrollment.Status = enrollment.Status;
        existingEnrollment.CompletedAt = enrollment.CompletedAt;
        existingEnrollment.Progress = enrollment.Progress;

        await _unitOfWork.Repository<Enrollment>().UpdateAsync(existingEnrollment, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return existingEnrollment;
    }
}