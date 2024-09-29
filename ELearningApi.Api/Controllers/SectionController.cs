using ELearningApi.Api.Base;
using ELearningApi.Core.MediatrHandlers.Section.Commands.CreateSection;
using ELearningApi.Core.MediatrHandlers.Section.Commands.DeleteSection;
using ELearningApi.Core.MediatrHandlers.Section.Commands.UpdateSection;
using ELearningApi.Core.MediatrHandlers.Section.Queries.GetSectionById;
using ELearningApi.Core.MediatrHandlers.Section.Queries.GetSectionsForCourse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Controllers;

/// <summary>
/// Controller for managing sections of a course.
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SectionController : AppControllerBase
{
    /// <summary>
    /// Creates a new section for a course.
    /// </summary>
    /// <param name="command">The create section command.</param>
    /// <returns>The created section.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Section
    ///     {
    ///         "title": "Introduction to C#",
    ///         "description": "Learn the basics of C# programming",
    ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Section created successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "title": "Introduction to C#",
    ///             "description": "Learn the basics of C# programming",
    ///             "orderIndex": 1,
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPost]
    public async Task<IActionResult> CreateSection([FromBody] CreateSectionCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves a specific section by its ID.
    /// </summary>
    /// <param name="id">The ID of the section to retrieve.</param>
    /// <returns>The requested section.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Section/3fa85f64-5717-4562-b3fc-2c963f66afa7
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "title": "Introduction to C#",
    ///             "description": "Learn the basics of C# programming",
    ///             "orderIndex": 1,
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///         }
    ///     }
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSectionById(Guid id)
    {
        var query = new GetSectionByIdQuery { Id = id };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Updates an existing section.
    /// </summary>
    /// <param name="id">The ID of the section to update.</param>
    /// <param name="command">The update section command.</param>
    /// <returns>The updated section.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /api/Section/3fa85f64-5717-4562-b3fc-2c963f66afa7
    ///     {
    ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///         "title": "Advanced C# Concepts",
    ///         "description": "Dive deeper into C# programming",
    ///         "orderIndex": 2,
    ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Section updated successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "title": "Advanced C# Concepts",
    ///             "description": "Dive deeper into C# programming",
    ///             "orderIndex": 2,
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSection(Guid id, [FromBody] UpdateSectionCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Deletes a specific section.
    /// </summary>
    /// <param name="id">The ID of the section to delete.</param>
    /// <returns>A success message if the section was deleted.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /api/Section/3fa85f64-5717-4562-b3fc-2c963f66afa7
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Section deleted successfully.",
    ///         "data": "Section deleted successfully."
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSection(Guid id)
    {
        var command = new DeleteSectionCommand { Id = id };
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves all sections for a specific course.
    /// </summary>
    /// <param name="courseId">The ID of the course.</param>
    /// <returns>A list of sections for the specified course.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Section/course/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "title": "Introduction to C#",
    ///                 "description": "Learn the basics of C# programming",
    ///                 "orderIndex": 1,
    ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///             },
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///                 "title": "Advanced C# Concepts",
    ///                 "description": "Dive deeper into C# programming",
    ///                 "orderIndex": 2,
    ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("course/{courseId}")]
    public async Task<IActionResult> GetSectionsForCourse(Guid courseId)
    {
        var query = new GetSectionsForCourseQuery { CourseId = courseId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }
}