using ELearningApi.Api.Base;
using ELearningApi.Core.MediatrHandlers.Enrollment.Commands.EnrollStudentInCourse;
using ELearningApi.Core.MediatrHandlers.Enrollment.Commands.UnEnrollStudentFromCourse;
using ELearningApi.Core.MediatrHandlers.Enrollment.Commands.UpdateEnrollmentStatus;
using ELearningApi.Core.MediatrHandlers.Enrollment.Queries.CheckEnrollmentStatus;
using ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentById;
using ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentsForCourse;
using ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentsForStudent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Controllers;

/// <summary>
/// Controller for managing student enrollments in courses.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class EnrollmentController : AppControllerBase
{
    /// <summary>
    /// Enrolls a student in a course.
    /// </summary>
    /// <param name="command">The enrollment command containing StudentId and CourseId.</param>
    /// <returns>The created enrollment details.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/Enrollment
    ///     {
    ///         "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///     }
    ///
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 201,
    ///         "succeeded": true,
    ///         "message": "Student enrolled successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "enrolledAt": "2023-06-07T10:00:00Z",
    ///             "status": "Enrolled",
    ///             "progress": 0
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Student")]
    [HttpPost]
    public async Task<IActionResult> EnrollStudentInCourse([FromBody] EnrollStudentInCourseCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Unenrolls a student from a course.
    /// </summary>
    /// <param name="command">The unenrollment command containing StudentId and CourseId.</param>
    /// <returns>A success message if the unenrollment is successful.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     DELETE /api/Enrollment
    ///     {
    ///         "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///     }
    ///
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Student unEnrolled successfully.",
    ///         "data": "Student unEnrolled successfully."
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Student")]
    [HttpDelete]
    public async Task<IActionResult> UnEnrollStudentFromCourse([FromBody] UnEnrollStudentFromCourseCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Updates the status of an enrollment.
    /// </summary>
    /// <param name="command">The update command containing EnrollmentId and NewStatus.</param>
    /// <returns>The updated enrollment details.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT /api/Enrollment
    ///     {
    ///         "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///         "newStatus": "Completed"
    ///     }
    ///
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Enrollment status updated successfully.",
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "enrolledAt": "2023-06-07T10:00:00Z",
    ///             "completedAt": "2023-06-14T15:30:00Z",
    ///             "status": "Completed",
    ///             "progress": 100
    ///         }
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpPut]
    public async Task<IActionResult> UpdateEnrollmentStatus([FromBody] UpdateEnrollmentStatusCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Checks the enrollment status of a student for a specific course.
    /// </summary>
    /// <param name="studentId">The ID of the student.</param>
    /// <param name="courseId">The ID of the course.</param>
    /// <returns>The enrollment status (true if enrolled, false otherwise).</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET /api/Enrollment/status?studentId=3fa85f64-5717-4562-b3fc-2c963f66afa6&amp;courseId=3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": "True"
    ///     }
    /// </remarks>
    [HttpGet("status")]
    public async Task<IActionResult> CheckEnrollmentStatus([FromQuery] Guid studentId, [FromQuery] Guid courseId)
    {
        var query = new CheckEnrollmentStatusQuery { StudentId = studentId, CourseId = courseId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves an enrollment by its ID.
    /// </summary>
    /// <param name="id">The ID of the enrollment.</param>
    /// <returns>The enrollment details.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET /api/Enrollment/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": {
    ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///             "enrolledAt": "2023-06-07T10:00:00Z",
    ///             "completedAt": null,
    ///             "status": "InProgress",
    ///             "progress": 50
    ///         }
    ///     }
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEnrollmentById(Guid id)
    {
        var query = new GetEnrollmentByIdQuery { EnrollmentId = id };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves all enrollments for a specific course.
    /// </summary>
    /// <param name="courseId">The ID of the course.</param>
    /// <returns>A list of enrollments for the specified course.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET /api/Enrollment/course/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "enrolledAt": "2023-06-07T10:00:00Z",
    ///                 "completedAt": null,
    ///                 "status": "InProgress",
    ///                 "progress": 50
    ///             },
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "enrolledAt": "2023-06-08T09:00:00Z",
    ///                 "completedAt": null,
    ///                 "status": "Enrolled",
    ///                 "progress": 0
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [Authorize(Roles = "Admin,Instructor")]
    [HttpGet("course/{courseId}")]
    public async Task<IActionResult> GetEnrollmentsForCourse(Guid courseId)
    {
        var query = new GetEnrollmentsForCourseQuery { CourseId = courseId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }

    /// <summary>
    /// Retrieves all enrollments for a specific student.
    /// </summary>
    /// <param name="studentId">The ID of the student.</param>
    /// <returns>A list of enrollments for the specified student.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET /api/Enrollment/student/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "data": [
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "enrolledAt": "2023-06-07T10:00:00Z",
    ///                 "completedAt": null,
    ///                 "status": "InProgress",
    ///                 "progress": 50
    ///             },
    ///             {
    ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    ///                 "enrolledAt": "2023-06-08T09:00:00Z",
    ///                 "completedAt": "2023-06-15T14:30:00Z",
    ///                 "status": "Completed",
    ///                 "progress": 100
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> GetEnrollmentsForStudent(Guid studentId)
    {
        var query = new GetEnrollmentsForStudentQuery { StudentId = studentId };
        var result = await Mediator.Send(query);
        return CreateResponse(result);
    }
}