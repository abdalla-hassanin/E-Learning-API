using ELearningApi.Api.Base;
using ELearningApi.Core.MediatrHandlers.Category.Commands.CreateCategory;
using ELearningApi.Core.MediatrHandlers.Category.Commands.DeleteCategory;
using ELearningApi.Core.MediatrHandlers.Category.Commands.UpdateCategory;
using ELearningApi.Core.MediatrHandlers.Category.Queries.GetAllCategories;
using ELearningApi.Core.MediatrHandlers.Category.Queries.GetCategoryById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Controllers;

/// <summary>
/// Controller for managing categories in the e-learning system.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CategoryController : AppControllerBase
{
    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="command">The create category command.</param>
    /// <returns>The newly created category.</returns>
    /// <response code="201">Returns the newly created category.</response>
    /// <response code="400">If the command is invalid.</response>
    /// <response code="500">If there was an internal server error.</response>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/Category
    ///     {
    ///        "name": "Programming"
    ///     }
    ///
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 201,
    ///         "succeeded": true,
    ///         "message": "Category created successfully",
    ///         "errors": [],
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "name": "Programming",
    ///             "courseCount": 0
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves a specific category by id.
    /// </summary>
    /// <param name="id">The id of the category to retrieve.</param>
    /// <returns>The requested category.</returns>
    /// <response code="200">Returns the requested category.</response>
    /// <response code="404">If the category is not found.</response>
    /// <response code="500">If there was an internal server error.</response>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET /api/Category/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": null,
    ///         "errors": [],
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "name": "Programming",
    ///             "courseCount": 5
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor,Student")] 
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(Guid id)
    {
        var result = await Mediator.Send(new GetCategoryByIdQuery { Id = id });
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <returns>A list of all categories.</returns>
    /// <response code="200">Returns the list of categories.</response>
    /// <response code="500">If there was an internal server error.</response>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET /api/Category
    ///
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": null,
    ///         "errors": [],
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "name": "Programming",
    ///                 "courseCount": 5
    ///             },
    ///             {
    ///                 "id": "8a1b22c3-9d3e-4f5g-6h7i-8j9k0l1m2n3o",
    ///                 "name": "Data Science",
    ///                 "courseCount": 3
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor,Student")] 
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await Mediator.Send(new GetAllCategoriesQuery());
        return CreateResponse(result);
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="command">The update category command.</param>
    /// <returns>The updated category.</returns>
    /// <response code="200">Returns the updated category.</response>
    /// <response code="400">If the command is invalid.</response>
    /// <response code="404">If the category is not found.</response>
    /// <response code="500">If there was an internal server error.</response>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT /api/Category
    ///     {
    ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///         "name": "Advanced Programming"
    ///     }
    ///
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Category updated successfully",
    ///         "errors": [],
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "name": "Advanced Programming",
    ///             "courseCount": 5
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Deletes a specific category.
    /// </summary>
    /// <param name="id">The id of the category to delete.</param>
    /// <returns>A success message.</returns>
    /// <response code="200">If the category was successfully deleted.</response>
    /// <response code="404">If the category is not found.</response>
    /// <response code="500">If there was an internal server error.</response>
    /// <remarks>
    /// Sample request:
    /// 
    ///     DELETE /api/Category/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Category deleted successfully",
    ///         "errors": [],
    ///         "data": null
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var result = await Mediator.Send(new DeleteCategoryCommand { Id = id });
        return CreateResponse(result);
    }
}