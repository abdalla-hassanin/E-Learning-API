using ELearningApi.Api.Base;
using ELearningApi.Core.MediatrHandlers.Review.Commands.CreateReview;
using ELearningApi.Core.MediatrHandlers.Review.Commands.DeleteReview;
using ELearningApi.Core.MediatrHandlers.Review.Commands.UpdateReview;
using ELearningApi.Core.MediatrHandlers.Review.Queries.GetCourseAverageRating;
using ELearningApi.Core.MediatrHandlers.Review.Queries.GetReviewById;
using ELearningApi.Core.MediatrHandlers.Review.Queries.GetReviewsForCourse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Controllers;

/// <summary>
/// Controller for managing reviews.
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReviewController : AppControllerBase
{
    /// <summary>
    /// Creates a new review for a course.
    /// </summary>
    /// <param name="command">The create review command.</param>
    /// <returns>The created review.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Review
    ///     {
    ///         "rating": 4,
    ///         "comment": "Great course, very informative!",
    ///         "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 201,
    ///         "succeeded": true,
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///             "rating": 4,
    ///             "comment": "Great course, very informative!",
    ///             "createdAt": "2023-06-07T10:00:00Z",
    ///             "updatedAt": "2023-06-07T10:00:00Z",
    ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Student")]
    [HttpPost]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves a specific review by its ID.
    /// </summary>
    /// <param name="id">The ID of the review to retrieve.</param>
    /// <returns>The requested review.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Review/3fa85f64-5717-4562-b3fc-2c963f66afa8
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///             "rating": 4,
    ///             "comment": "Great course, very informative!",
    ///             "createdAt": "2023-06-07T10:00:00Z",
    ///             "updatedAt": "2023-06-07T10:00:00Z",
    ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
    ///         }
    ///     }
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReviewById(Guid id)
    {
        var query = new GetReviewByIdQuery { Id = id };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Updates an existing review.
    /// </summary>
    /// <param name="id">The ID of the review to update.</param>
    /// <param name="command">The update review command.</param>
    /// <returns>The updated review.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /api/Review/3fa85f64-5717-4562-b3fc-2c963f66afa8
    ///     {
    ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///         "rating": 5,
    ///         "comment": "Excellent course, highly recommended!"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///             "rating": 5,
    ///             "comment": "Excellent course, highly recommended!",
    ///             "createdAt": "2023-06-07T10:00:00Z",
    ///             "updatedAt": "2023-06-07T11:00:00Z",
    ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Student")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReview(Guid id, [FromBody] UpdateReviewCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("The ID in the URL does not match the ID in the request body.");
        }

        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Deletes a specific review.
    /// </summary>
    /// <param name="id">The ID of the review to delete.</param>
    /// <returns>A success message if the review was deleted.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /api/Review/3fa85f64-5717-4562-b3fc-2c963f66afa8
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Review deleted successfully.",
    ///         "data": "Review deleted successfully."
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Student")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(Guid id)
    {
        var command = new DeleteReviewCommand { Id = id };
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves reviews for a specific course.
    /// </summary>
    /// <param name="courseId">The ID of the course.</param>
    /// <param name="page">The page number (default is 1).</param>
    /// <param name="pageSize">The number of items per page (default is 10).</param>
    /// <returns>A paged list of reviews for the specified course.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Review/course/3fa85f64-5717-4562-b3fc-2c963f66afa7?page=1&amp;pageSize=10
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": {
    ///             "items": [
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///                     "rating": 5,
    ///                     "comment": "Excellent course, highly recommended!",
    ///                     "createdAt": "2023-06-07T10:00:00Z",
    ///                     "updatedAt": "2023-06-07T11:00:00Z",
    ///                     "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                     "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
    ///                 },
    ///                 {
    ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
    ///                     "rating": 4,
    ///                     "comment": "Very informative course.",
    ///                     "createdAt": "2023-06-06T15:00:00Z",
    ///                     "updatedAt": "2023-06-06T15:00:00Z",
    ///                     "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afaa",
    ///                     "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
    ///                 }
    ///             ],
    ///             "pageNumber": 1,
    ///             "pageSize": 10,
    ///             "totalCount": 2,
    ///             "totalPages": 1,
    ///             "hasPreviousPage": false,
    ///             "hasNextPage": false
    ///         }
    ///     }
    /// </remarks>
    [HttpGet("course/{courseId}")]
    public async Task<IActionResult> GetReviewsForCourse(Guid courseId, [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var query = new GetReviewsForCourseQuery { CourseId = courseId, Page = page, PageSize = pageSize };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Calculates the average rating for a specific course.
    /// </summary>
    /// <param name="courseId">The ID of the course.</param>
    /// <returns>The average rating for the specified course.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Review/average-rating/3fa85f64-5717-4562-b3fc-2c963f66afa7
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": "4.5"
    ///     }
    /// </remarks>
    [HttpGet("average-rating/{courseId}")]
    public async Task<IActionResult> GetCourseAverageRating(Guid courseId)
    {
        var query = new GetCourseAverageRatingQuery { CourseId = courseId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }
}