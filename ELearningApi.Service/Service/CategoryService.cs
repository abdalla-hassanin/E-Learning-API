using ELearningApi.Data.Entities;
using ELearningApi.Infrustructure.Base;
using ELearningApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace ELearningApi.Service.Service;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Category> CreateCategoryAsync(Category category, CancellationToken cancellationToken = default)
    {
        if (category == null)
            throw new ArgumentNullException(nameof(category));

        await _unitOfWork.Repository<Category>().AddAsync(category, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return category;
    }

    public async Task<Category> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var categories = await _unitOfWork.Repository<Category>().FindAsync(
            c => c.Id == id,
            include: query => query.Include(c => c.Courses),
            cancellationToken: cancellationToken
        );

        var category = categories.FirstOrDefault();

        if (category == null)
            throw new KeyNotFoundException($"Category with ID {id} not found.");

        return category;
    }
    
    public async Task<Category> UpdateCategoryAsync(Category category, CancellationToken cancellationToken = default)
    {
        if (category == null)
            throw new ArgumentNullException(nameof(category));

        var existingCategory = await GetCategoryByIdAsync(category.Id, cancellationToken);

        existingCategory.Name = category.Name;
        // Add any other properties that need updating

        await _unitOfWork.Repository<Category>().UpdateAsync(existingCategory, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return existingCategory;
    }

    public async Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await GetCategoryByIdAsync(id, cancellationToken);

        if (category.Courses.Count > 0)
            throw new InvalidOperationException("Cannot delete a category that has associated courses.");

        await _unitOfWork.Repository<Category>().RemoveAsync(category, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.Repository<Category>().FindAsync(c => true,include:query=>query.Include(c=>c.Courses),cancellationToken);
    }
}