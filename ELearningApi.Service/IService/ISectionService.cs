using ELearningApi.Data.Entities;

namespace ELearningApi.Service.IService;

public interface ISectionService
{
    Task<Section> CreateSectionAsync(Section section, CancellationToken cancellationToken = default);
    Task<Section> GetSectionByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Section> UpdateSectionAsync(Section section, CancellationToken cancellationToken = default);
    Task DeleteSectionAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Section>> GetSectionsForCourseAsync(Guid courseId, CancellationToken cancellationToken = default);
}
