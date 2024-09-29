using ELearningApi.Api.Base;
using ELearningApi.Core.MediatrHandlers.Search.GlobalSearch;
using ELearningApi.Core.MediatrHandlers.Search.SearchCourses;
using ELearningApi.Core.MediatrHandlers.Search.SearchInstructors;
using ELearningApi.Core.MediatrHandlers.Search.SearchLectures;
using ELearningApi.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Controllers;

/// <summary>
/// Controller for handling search-related operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SearchController : AppControllerBase
{
    /// <summary>
    /// Performs a global search across courses, instructors, and lectures.
    /// </summary>
    /// <param name="searchTerm">The term to search for.</param>
    /// <returns>A collection of courses, instructors, and lectures that match the search term.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Search/global?searchTerm=programming
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Global search completed successfully.",
    ///         "data": {
    ///             "courses": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                     "title": "Introduction to Programming",
    ///                     "shortDescription": "Learn the basics of programming",
    ///                     "price": 49.99,
    ///                     "instructorName": "John Doe",
    ///                     "categoryName": "Computer Science",
    ///                     "level": 0,
    ///                     "estimatedDuration": "10:00:00"
    ///                 }
    ///             ],
    ///             "instructors": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                     "name": "Jane Smith",
    ///                     "email": "jane.smith@example.com",
    ///                     "expertise": "Programming, Web Development",
    ///                     "biography": "Experienced programmer with 10 years in the industry"
    ///                 }
    ///             ],
    ///             "lectures": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///                     "title": "Variables and Data Types",
    ///                     "description": "Understanding basic programming concepts",
    ///                     "duration": "00:45:00",
    ///                     "courseName": "Introduction to Programming",
    ///                     "sectionName": "Basics of Programming"
    ///                 }
    ///             ]
    ///         }
    ///     }
    /// </remarks>
    [HttpGet("global")]
    public async Task<IActionResult> GlobalSearch([FromQuery] string searchTerm)
    {
        var query = new GlobalSearchQuery { SearchTerm = searchTerm };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Searches for courses based on various criteria.
    /// </summary>
    /// <param name="searchTerm">The term to search for in course titles and descriptions.</param>
    /// <param name="level">The course level to filter by (optional).</param>
    /// <param name="categoryId">The category ID to filter by (optional).</param>
    /// <param name="minPrice">The minimum price to filter by (optional).</param>
    /// <param name="maxPrice">The maximum price to filter by (optional).</param>
    /// <returns>A collection of courses that match the search criteria.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Search/courses?searchTerm=programming&amp;level=1&amp;categoryId=3fa85f64-5717-4562-b3fc-2c963f66afa9&amp;minPrice=20&amp;maxPrice=100
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Courses retrieved successfully.",
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "title": "Advanced Programming Techniques",
    ///                 "shortDescription": "Take your programming skills to the next level",
    ///                 "price": 79.99,
    ///                 "instructorName": "John Doe",
    ///                 "categoryName": "Computer Science",
    ///                 "level": 1,
    ///                 "estimatedDuration": "15:00:00"
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("courses")]
    public async Task<IActionResult> SearchCourses(
        [FromQuery] string searchTerm,
        [FromQuery] CourseLevel? level = null,
        [FromQuery] Guid? categoryId = null,
        [FromQuery] decimal? minPrice = null,
        [FromQuery] decimal? maxPrice = null)
    {
        var query = new SearchCoursesQuery
        {
            SearchTerm = searchTerm,
            Level = level,
            CategoryId = categoryId,
            MinPrice = minPrice,
            MaxPrice = maxPrice
        };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Searches for instructors based on a search term and expertise.
    /// </summary>
    /// <param name="searchTerm">The term to search for in instructor names and biographies.</param>
    /// <param name="expertise">The expertise to filter by (optional).</param>
    /// <returns>A collection of instructors that match the search criteria.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Search/instructors?searchTerm=programming&amp;expertise=web development
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Instructors retrieved successfully.",
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "name": "Jane Smith",
    ///                 "email": "jane.smith@example.com",
    ///                 "expertise": "Programming, Web Development",
    ///                 "biography": "Experienced programmer with 10 years in the industry"
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("instructors")]
    public async Task<IActionResult> SearchInstructors([FromQuery] string searchTerm,
        [FromQuery] string? expertise = null)
    {
        var query = new SearchInstructorsQuery { SearchTerm = searchTerm, Expertise = expertise };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Searches for lectures based on a search term and optionally filtered by course.
    /// </summary>
    /// <param name="searchTerm">The term to search for in lecture titles, descriptions, and content.</param>
    /// <param name="courseId">The course ID to filter by (optional).</param>
    /// <returns>A collection of lectures that match the search criteria.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Search/lectures?searchTerm=variables&amp;courseId=3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Lectures retrieved successfully.",
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///                 "title": "Variables and Data Types",
    ///                 "description": "Understanding basic programming concepts",
    ///                 "duration": "00:45:00",
    ///                 "courseName": "Introduction to Programming",
    ///                 "sectionName": "Basics of Programming"
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("lectures")]
    public async Task<IActionResult> SearchLectures([FromQuery] string searchTerm, [FromQuery] Guid? courseId = null)
    {
        var query = new SearchLecturesQuery { SearchTerm = searchTerm, CourseId = courseId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }
}