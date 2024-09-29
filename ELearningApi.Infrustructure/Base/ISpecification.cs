using System.Linq.Expressions;

namespace ELearningApi.Infrustructure.Base;

public interface ISpecification<T>
{
    // The criteria that the entity must satisfy
    Expression<Func<T, bool>> Criteria { get; }

    // Include related entities
    List<Func<IQueryable<T>, IQueryable<T>>> Includes { get; }

    // Sorting
    Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; }

    // Pagination
    int? Skip { get; }
    int? Take { get; }
}
