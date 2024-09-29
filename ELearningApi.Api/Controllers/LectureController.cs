using ELearningApi.Api.Base;
using ELearningApi.Core.MediatrHandlers.Lecture.Command.AddResourceToLecture;
using ELearningApi.Core.MediatrHandlers.Lecture.Command.CreateLecture;
using ELearningApi.Core.MediatrHandlers.Lecture.Command.DeleteLecture;
using ELearningApi.Core.MediatrHandlers.Lecture.Command.RemoveResourceFromLecture;
using ELearningApi.Core.MediatrHandlers.Lecture.Command.UpdateLecture;
using ELearningApi.Core.MediatrHandlers.Lecture.Queries.GetLectureById;
using ELearningApi.Core.MediatrHandlers.Lecture.Queries.GetLecturesForSection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Controllers;

/// <summary>
/// Controller for managing lectures.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LectureController : AppControllerBase
{
    /// <summary>
    /// Creates a new lecture.
    /// </summary>
    /// <param name="command">The create lecture command.</param>
    /// <returns>The created lecture.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Lecture
    ///     {
    ///         "title": "Introduction to C#",
    ///         "description": "Learn the basics of C# programming",
    ///         "content": "C# is a modern, object-oriented programming language...",
    ///         "duration": "01:30:00",
    ///         "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///         "type": 0,
    ///         "videoUrl": "https://example.com/video.mp4"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Lecture created successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "title": "Introduction to C#",
    ///             "description": "Learn the basics of C# programming",
    ///             "content": "C# is a modern, object-oriented programming language...",
    ///             "duration": "01:30:00",
    ///             "orderIndex": 1,
    ///             "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "type": 0,
    ///             "videoUrl": "https://example.com/video.mp4",
    ///             "resources": []
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPost]
    public async Task<IActionResult> CreateLecture([FromBody] CreateLectureCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves a lecture by its ID.
    /// </summary>
    /// <param name="id">The ID of the lecture to retrieve.</param>
    /// <returns>The requested lecture.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Lecture/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Lecture retrieved successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "title": "Introduction to C#",
    ///             "description": "Learn the basics of C# programming",
    ///             "content": "C# is a modern, object-oriented programming language...",
    ///             "duration": "01:30:00",
    ///             "orderIndex": 1,
    ///             "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "type": 0,
    ///             "videoUrl": "https://example.com/video.mp4",
    ///             "resources": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                     "title": "C# Cheat Sheet",
    ///                     "description": "Quick reference for C# syntax",
    ///                     "url": "https://example.com/csharp-cheatsheet.pdf",
    ///                     "type": 0
    ///                 }
    ///             ]
    ///         }
    ///     }
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLectureById(Guid id)
    {
        var query = new GetLectureByIdQuery { Id = id };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Updates an existing lecture.
    /// </summary>
    /// <param name="id">The ID of the lecture to update.</param>
    /// <param name="command">The update lecture command.</param>
    /// <returns>The updated lecture.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /api/Lecture/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///     {
    ///         "title": "Advanced C# Concepts",
    ///         "description": "Explore advanced topics in C# programming",
    ///         "content": "In this lecture, we'll dive deeper into C# concepts...",
    ///         "duration": "02:00:00",
    ///         "orderIndex": 2,
    ///         "type": 1,
    ///         "videoUrl": "https://example.com/advanced-csharp.mp4"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Lecture updated successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "title": "Advanced C# Concepts",
    ///             "description": "Explore advanced topics in C# programming",
    ///             "content": "In this lecture, we'll dive deeper into C# concepts...",
    ///             "duration": "02:00:00",
    ///             "orderIndex": 2,
    ///             "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "type": 1,
    ///             "videoUrl": "https://example.com/advanced-csharp.mp4",
    ///             "resources": []
    ///         }
    ///     }
    /// </remarks>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Instructor")]
    public async Task<IActionResult> UpdateLecture(Guid id, [FromBody] UpdateLectureCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Deletes a lecture.
    /// </summary>
    /// <param name="id">The ID of the lecture to delete.</param>
    /// <returns>A success message if the lecture was deleted.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /api/Lecture/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Lecture deleted successfully.",
    ///         "data": "Lecture deleted successfully."
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLecture(Guid id)
    {
        var command = new DeleteLectureCommand { Id = id };
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves all lectures for a specific section.
    /// </summary>
    /// <param name="sectionId">The ID of the section.</param>
    /// <returns>A list of lectures in the specified section.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Lecture/section/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Lectures retrieved successfully.",
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "title": "Introduction to C#",
    ///                 "description": "Learn the basics of C# programming",
    ///                 "content": "C# is a modern, object-oriented programming language...",
    ///                 "duration": "01:30:00",
    ///                 "orderIndex": 1,
    ///                 "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "type": 0,
    ///                 "videoUrl": "https://example.com/video.mp4",
    ///                 "resources": []
    ///             },
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "title": "Advanced C# Concepts",
    ///                 "description": "Explore advanced topics in C# programming",
    ///                 "content": "In this lecture, we'll dive deeper into C# concepts...",
    ///                 "duration": "02:00:00",
    ///                 "orderIndex": 2,
    ///                 "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "type": 1,
    ///                 "videoUrl": "https://example.com/advanced-csharp.mp4",
    ///                 "resources": []
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("section/{sectionId}")]
    public async Task<IActionResult> GetLecturesForSection(Guid sectionId)
    {
        var query = new GetLecturesForSectionQuery { SectionId = sectionId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Adds a resource to a lecture.
    /// </summary>
    /// <param name="lectureId">The ID of the lecture to add the resource to.</param>
    /// <param name="command">The add resource command.</param>
    /// <returns>The updated lecture with the new resource.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Lecture/3fa85f64-5717-4562-b3fc-2c963f66afa6/resource
    ///     {
    ///         "title": "C# Cheat Sheet",
    ///         "description": "Quick reference for C# syntax",
    ///         "url": "https://example.com/csharp-cheatsheet.pdf",
    ///         "type": 0
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Resource added to lecture successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "title": "Introduction to C#",
    ///             "description": "Learn the basics of C# programming",
    ///             "content": "C# is a modern, object-oriented programming language...",
    ///             "duration": "01:30:00",
    ///             "orderIndex": 1,
    ///             "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "type": 0,
    ///             "videoUrl": "https://example.com/video.mp4",
    ///             "resources": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                     "title": "C# Cheat Sheet",
    ///                     "description": "Quick reference for C# syntax",
    ///                     "url": "https://example.com/csharp-cheatsheet.pdf",
    ///                     "type": 0
    ///                 }
    ///             ]
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPost("{lectureId}/resource")]
    public async Task<IActionResult> AddResourceToLecture(Guid lectureId, [FromBody] AddResourceToLectureCommand command)
    {
        if (lectureId != command.LectureId)
        {
            return BadRequest("The lecture ID in the URL does not match the lecture ID in the request body.");
        }
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Removes a resource from a lecture.
    /// </summary>
    /// <param name="lectureId">The ID of the lecture to remove the resource from.</param>
    /// <param name="resourceId">The ID of the resource to remove.</param>
    /// <returns>The updated lecture without the removed resource.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /api/Lecture/3fa85f64-5717-4562-b3fc-2c963f66afa6/resource/3fa85f64-5717-4562-b3fc-2c963f66afa7
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Resource removed from lecture successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "title": "Introduction to C#",
    ///             "description": "Learn the basics of C# programming",
    ///             "content": "C# is a modern, object-oriented programming language...",
    ///             "duration": "01:30:00",
    ///             "orderIndex": 1,
    ///             "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "type": 0,
    ///             "videoUrl": "https://example.com/video.mp4",
    ///             "resources": []
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpDelete("{lectureId}/resource/{resourceId}")]
    public async Task<IActionResult> RemoveResourceFromLecture(Guid lectureId, Guid resourceId)
    {
        var command = new RemoveResourceFromLectureCommand { LectureId = lectureId, ResourceId = resourceId };
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }
}
