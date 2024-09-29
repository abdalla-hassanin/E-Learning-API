using ELearningApi.Api.Base;
using ELearningApi.Core.MediatrHandlers.Progress.Commands.MarkLectureComplete;
using ELearningApi.Core.MediatrHandlers.Progress.Commands.ResetProgress;
using ELearningApi.Core.MediatrHandlers.Progress.Commands.UpdateProgress;
using ELearningApi.Core.MediatrHandlers.Progress.Queries.GetCompletedLectures;
using ELearningApi.Core.MediatrHandlers.Progress.Queries.GetOverallCourseProgress;
using ELearningApi.Core.MediatrHandlers.Progress.Queries.GetProgressById;
using ELearningApi.Core.MediatrHandlers.Progress.Queries.GetProgressForEnrollment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Controllers;

/// <summary>
/// Controller for managing student progress.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class ProgressController : AppControllerBase
{
    /// <summary>
    /// Updates the progress of a student for a specific lecture.
    /// </summary>
    /// <param name="command">The update progress command.</param>
    /// <returns>The updated progress information.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Progress/update
    ///     {
    ///         "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///         "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///         "progressPercentage": 75,
    ///         "status": 1
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Progress updated successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///             "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "startedAt": "2023-06-07T10:00:00Z",
    ///             "completedAt": null,
    ///             "status": 1,
    ///             "progressPercentage": 75
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Student")]
    [HttpPost("update")]
    public async Task<IActionResult> UpdateProgress([FromBody] UpdateProgressCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Marks a lecture as complete for a student.
    /// </summary>
    /// <param name="command">The mark lecture complete command.</param>
    /// <returns>The updated progress information.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Progress/complete
    ///     {
    ///         "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///         "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Lecture marked as complete.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///             "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "startedAt": "2023-06-07T10:00:00Z",
    ///             "completedAt": "2023-06-07T11:30:00Z",
    ///             "status": 2,
    ///             "progressPercentage": 100
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Student")]
    [HttpPost("complete")]
    public async Task<IActionResult> MarkLectureComplete([FromBody] MarkLectureCompleteCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Resets the progress for a student's enrollment.
    /// </summary>
    /// <param name="command">The reset progress command.</param>
    /// <returns>A success message if the progress was reset.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/Progress/reset
    ///     {
    ///         "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///     }
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Progress reset successfully.",
    ///         "data": "Progress reset successfully."
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPost("reset")]
    public async Task<IActionResult> ResetProgress([FromBody] ResetProgressCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves the progress for a specific enrollment.
    /// </summary>
    /// <param name="enrollmentId">The ID of the enrollment.</param>
    /// <returns>A list of progress entries for the enrollment.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Progress/enrollment/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///                 "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "startedAt": "2023-06-07T10:00:00Z",
    ///                 "completedAt": "2023-06-07T11:30:00Z",
    ///                 "status": 2,
    ///                 "progressPercentage": 100
    ///             },
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
    ///                 "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afb0",
    ///                 "startedAt": "2023-06-08T09:00:00Z",
    ///                 "completedAt": null,
    ///                 "status": 1,
    ///                 "progressPercentage": 50
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("enrollment/{enrollmentId}")]
    public async Task<IActionResult> GetProgressForEnrollment(Guid enrollmentId)
    {
        var query = new GetProgressForEnrollmentQuery { EnrollmentId = enrollmentId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves the overall course progress for a student.
    /// </summary>
    /// <param name="studentId">The ID of the student.</param>
    /// <param name="courseId">The ID of the course.</param>
    /// <returns>The overall progress percentage for the course.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Progress/overall?studentId=3fa85f64-5717-4562-b3fc-2c963f66afa6&amp;courseId=3fa85f64-5717-4562-b3fc-2c963f66afa7
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": "75"
    ///     }
    /// </remarks>
    [HttpGet("overall")]
    public async Task<IActionResult> GetOverallCourseProgress([FromQuery] Guid studentId, [FromQuery] Guid courseId)
    {
        var query = new GetOverallCourseProgressQuery { StudentId = studentId, CourseId = courseId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves a list of completed lectures for a student in a course.
    /// </summary>
    /// <param name="studentId">The ID of the student.</param>
    /// <param name="courseId">The ID of the course.</param>
    /// <returns>A list of completed lectures.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Progress/completed?studentId=3fa85f64-5717-4562-b3fc-2c963f66afa6&amp;courseId=3fa85f64-5717-4562-b3fc-2c963f66afa7
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///                 "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "startedAt": "2023-06-07T10:00:00Z",
    ///                 "completedAt": "2023-06-07T11:30:00Z",
    ///                 "status": 2,
    ///                 "progressPercentage": 100
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("completed")]
    public async Task<IActionResult> GetCompletedLectures([FromQuery] Guid studentId, [FromQuery] Guid courseId)
    {
        var query = new GetCompletedLecturesQuery { StudentId = studentId, CourseId = courseId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves progress details by ID.
    /// </summary>
    /// <param name="id">The ID of the progress entry.</param>
    /// <returns>The progress details for the specified ID.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/Progress/3fa85f64-5717-4562-b3fc-2c963f66afa8
    ///
    /// Sample response:
    ///
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
    ///             "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///             "startedAt": "2023-06-07T10:00:00Z",
    ///             "completedAt": "2023-06-07T11:30:00Z",
    ///             "status": 2,
    ///             "progressPercentage": 100
    ///         }
    ///     }
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProgressById(Guid id)
    {
        var query = new GetProgressByIdQuery { Id = id };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }
}