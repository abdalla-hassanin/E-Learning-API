using ELearningApi.Data.Entities;

namespace ELearningApi.Service.IService;

public interface IInstructorService
{
    Task<Instructor> GetInstructorByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Instructor>> GetAllInstructorsAsync(CancellationToken cancellationToken = default);
    Task<Instructor> CreateInstructorAsync(Instructor instructor, CancellationToken cancellationToken = default);
    Task<Instructor> UpdateInstructorAsync(Instructor instructor, CancellationToken cancellationToken = default);
    Task DeleteInstructorAsync(Guid id, CancellationToken cancellationToken = default);
}
