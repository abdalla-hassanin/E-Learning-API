using ELearningApi.Data.Entities;
using ELearningApi.Service.Base;

namespace ELearningApi.Service.IService;

public interface IStudentService
{
    Task<Student> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Student>> GetAllStudentsAsync(CancellationToken cancellationToken = default);
    Task<Student> CreateStudentAsync(Student student, CancellationToken cancellationToken = default);
    Task<Student> UpdateStudentAsync(Student student, CancellationToken cancellationToken = default);
    Task DeleteStudentAsync(Guid id, CancellationToken cancellationToken = default);
}
