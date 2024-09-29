using ELearningApi.Api.Base;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Core.MediatrHandlers.Course;
using ELearningApi.Core.MediatrHandlers.Course.Commands.CreateCourse;
using ELearningApi.Core.MediatrHandlers.Course.Commands.DeleteCourse;
using ELearningApi.Core.MediatrHandlers.Course.Commands.UpdateCourse;
using ELearningApi.Core.MediatrHandlers.Course.Queries.GetCourseById;
using ELearningApi.Core.MediatrHandlers.Course.Queries.GetCourseRating;
using ELearningApi.Core.MediatrHandlers.Course.Queries.GetCoursesByCategory;
using ELearningApi.Core.MediatrHandlers.Course.Queries.GetCoursesByInstructor;
using ELearningApi.Core.MediatrHandlers.Course.Queries.SearchCourses;
using ELearningApi.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Controllers;

/// <summary>
/// Controller for managing courses in the e-learning system.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class CourseController : AppControllerBase
{
    /// <summary>
    /// Creates a new course.
    /// </summary>
    /// <param name="command">The course creation command.</param>
    /// <returns>The created course.</returns>
    /// <response code="201">Returns the newly created course</response>
    /// <response code="400">If the course data is invalid</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Course
    ///     {
    ///        "title": "Introduction to C#",
    ///        "description": "Learn the basics of C# programming",
    ///        "shortDescription": "Start your C# journey",
    ///        "price": 49.99,
    ///        "instructorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///        "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///        "thumbnailUrl": "https://example.com/thumbnail.jpg",
    ///        "trailerVideoUrl": "https://example.com/trailer.mp4",
    ///        "level": "Beginner",
    ///        "prerequisites": ["Basic programming knowledge"],
    ///        "learningObjectives": ["Understand C# syntax", "Write simple C# programs"],
    ///        "estimatedDuration": "10:00:00"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///        "statusCode": 201,
    ///        "succeeded": true,
    ///        "message": "Course created successfully",
    ///        "data": {
    ///           "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///           "title": "Introduction to C#",
    ///           "description": "Learn the basics of C# programming",
    ///           "shortDescription": "Start your C# journey",
    ///           "price": 49.99,
    ///           "instructorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///           "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///           "thumbnailUrl": "https://example.com/thumbnail.jpg",
    ///           "trailerVideoUrl": "https://example.com/trailer.mp4",
    ///           "level": "Beginner",
    ///           "prerequisites": ["Basic programming knowledge"],
    ///           "learningObjectives": ["Understand C# syntax", "Write simple C# programs"],
    ///           "estimatedDuration": "10:00:00",
    ///           "createdAt": "2023-06-01T12:00:00Z",
    ///           "updatedAt": "2023-06-01T12:00:00Z"
    ///        }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves a specific course by id.
    /// </summary>
    /// <param name="id">The id of the course to retrieve.</param>
    /// <returns>The requested course.</returns>
    /// <response code="200">Returns the requested course</response>
    /// <response code="404">If the course is not found</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Course/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///        "statusCode": 200,
    ///        "succeeded": true,
    ///        "data": {
    ///           "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///           "title": "Introduction to C#",
    ///           "description": "Learn the basics of C# programming",
    ///           "shortDescription": "Start your C# journey",
    ///           "price": 49.99,
    ///           "instructorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///           "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///           "thumbnailUrl": "https://example.com/thumbnail.jpg",
    ///           "trailerVideoUrl": "https://example.com/trailer.mp4",
    ///           "level": "Beginner",
    ///           "prerequisites": ["Basic programming knowledge"],
    ///           "learningObjectives": ["Understand C# syntax", "Write simple C# programs"],
    ///           "estimatedDuration": "10:00:00",
    ///           "createdAt": "2023-06-01T12:00:00Z",
    ///           "updatedAt": "2023-06-01T12:00:00Z"
    ///        }
    ///     }
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourse(Guid id)
    {
        var result = await Mediator.Send(new GetCourseByIdQuery { Id = id });
        return CreateResponse(result);
    }

    /// <summary>
    /// Updates an existing course.
    /// </summary>
    /// <param name="id">The id of the course to update.</param>
    /// <param name="command">The course update command.</param>
    /// <returns>The updated course.</returns>
    /// <response code="200">Returns the updated course</response>
    /// <response code="400">If the course data is invalid</response>
    /// <response code="404">If the course is not found</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /api/Course/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///     {
    ///        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///        "title": "Advanced C# Programming",
    ///        "description": "Take your C# skills to the next level",
    ///        "price": 79.99,
    ///        "level": "Intermediate"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///        "statusCode": 200,
    ///        "succeeded": true,
    ///        "message": "Course updated successfully",
    ///        "data": {
    ///           "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///           "title": "Advanced C# Programming",
    ///           "description": "Take your C# skills to the next level",
    ///           "price": 79.99,
    ///           "level": "Intermediate",
    ///           "updatedAt": "2023-06-02T10:30:00Z"
    ///        }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(Guid id, [FromBody] UpdateCourseCommand command)
    {
        if (id != command.Id)
            return BadRequest(new ApiResponse<CourseDto> { Succeeded = false, Message = "ID mismatch" });

        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Deletes a specific course.
    /// </summary>
    /// <param name="id">The id of the course to delete.</param>
    /// <returns>A success message.</returns>
    /// <response code="200">If the course was successfully deleted</response>
    /// <response code="404">If the course is not found</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /api/Course/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///        "statusCode": 200,
    ///        "succeeded": true,
    ///        "message": "Course deleted successfully"
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        var result = await Mediator.Send(new DeleteCourseCommand { Id = id });
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves courses by category.
    /// </summary>
    /// <param name="categoryId">The id of the category.</param>
    /// <returns>A list of courses in the specified category.</returns>
    /// <response code="200">Returns the list of courses</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Course/category/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///        "statusCode": 200,
    ///        "succeeded": true,
    ///        "data": [
    ///           {
    ///              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///              "title": "Introduction to C#",
    ///              "shortDescription": "Start your C# journey",
    ///              "price": 49.99,
    ///              "level": "Beginner"
    ///           },
    ///           {
    ///              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///              "title": "Advanced C# Programming",
    ///              "shortDescription": "Take your C# skills to the next level",
    ///              "price": 79.99,
    ///              "level": "Intermediate"
    ///           }
    ///        ]
    ///     }
    /// </remarks>
    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetCoursesByCategory(Guid categoryId)
    {
        var result = await Mediator.Send(new GetCoursesByCategoryQuery { CategoryId = categoryId });
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves courses by instructor.
    /// </summary>
    /// <param name="instructorId">The id of the instructor.</param>
    /// <returns>A list of courses by the specified instructor.</returns>
    /// <response code="200">Returns the list of courses</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Course/instructor/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///        "statusCode": 200,
    ///        "succeeded": true,
    ///        "data": [
    ///           {
    ///              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///              "title": "Introduction to C#",
    ///              "shortDescription": "Start your C# journey",
    ///              "price": 49.99,
    ///              "level": "Beginner"
    ///           },
    ///           {
    ///              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///              "title": "Advanced C# Programming",
    ///              "shortDescription": "Take your C# skills to the next level",
    ///              "price": 79.99,
    ///              "level": "Intermediate"
    ///           }
    ///        ]
    ///     }
    /// </remarks>
    [HttpGet("instructor/{instructorId}")]
    public async Task<IActionResult> GetCoursesByInstructor(Guid instructorId)
    {
        var result = await Mediator.Send(new GetCoursesByInstructorQuery { InstructorId = instructorId });
        return CreateResponse(result);
    }

    /// <summary>
    /// Searches for courses based on various criteria.
    /// </summary>
    /// <param name="searchTerm">The search term to filter courses.</param>
    /// <param name="pageNumber">The page number for pagination.</param>
    /// <param name="pageSize">The page size for pagination.</param>
    /// <param name="level">The course level to filter by (optional).</param>
    /// <param name="categoryId">The category id to filter by (optional).</param>
    /// <returns>A paginated list of courses matching the search criteria.</returns>
    /// <response code="200">Returns the list of courses</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Course/search?searchTerm=C%23&amp;pageNumber=1&amp;pageSize=10&amp;level=Beginner&amp;categoryId=3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///        "statusCode": 200,
    ///        "succeeded": true,
    ///        "data": {
    ///           "courses": [
    ///              {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "title": "Introduction to C#",
    ///                 "shortDescription": "Start your C# journey",
    ///                 "price": 49.99,
    ///                 "level": "Beginner"
    ///              },
    ///              {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "title": "C# for Beginners",
    ///                 "shortDescription": "Learn C# from scratch",
    ///                 "price": 39.99,
    ///                 "level": "Beginner"
    ///              }
    ///           ],
    ///           "totalCount": 2
    ///        }
    ///     }
    /// </remarks>
    [HttpGet("search")]
    public async Task<IActionResult> SearchCourses(
        [FromQuery] string searchTerm,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] CourseLevel? level = null,
        [FromQuery] Guid? categoryId = null)
    {
        var query = new SearchCoursesQuery
        {
            SearchTerm = searchTerm,
            PageNumber = pageNumber,
            PageSize = pageSize,
            Level = level,
            CategoryId = categoryId
        };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves the rating for a specific course.
    /// </summary>
    /// <param name="courseId">The id of the course.</param>
    /// <returns>The course rating.</returns>
    /// <response code="200">Returns the course rating</response>
    /// <response code="404">If the course is not found</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Course/3fa85f64-5717-4562-b3fc-2c963f66afa6/rating
    ///
    /// Sample response:
    ///
    ///     {
    ///        "statusCode": 200,
    ///        "succeeded": true,
    ///        "data": "4.5"
    ///     }
    /// </remarks>
    [HttpGet("{courseId}/rating")]
    public async Task<IActionResult> GetCourseRating(Guid courseId)
    {
        var result = await Mediator.Send(new GetCourseRatingQuery { CourseId = courseId });
        return CreateResponse(result);
    }
}