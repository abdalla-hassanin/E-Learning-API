using ELearningApi.Api.Base;
using Microsoft.AspNetCore.Mvc;
using ELearningApi.Core.MediatrHandlers.Student.Commands.UpdateStudent;
using ELearningApi.Core.MediatrHandlers.Student.Queries.GetAllStudents;
using ELearningApi.Core.MediatrHandlers.Student.Queries.GetStudentById;
using Microsoft.AspNetCore.Authorization;

namespace ELearningApi.Api.Controllers
{
    /// <summary>
    /// Controller for managing students.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : AppControllerBase
    {
        /// <summary>
        /// Gets a student by id.
        /// </summary>
        /// <param name="id">The id of the student.</param>
        /// <returns>The student.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/students/3fa85f64-5717-4562-b3fc-2c963f66afa6
        /// 
        /// Sample response:
        /// 
        ///     {
        ///         "data": {
        ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///             "firstName": "John",
        ///             "lastName": "Doe",
        ///             "email": "john.doe@example.com"
        ///         },
        ///         "message": "Student retrieved successfully.",
        ///         "statusCode": 200,
        ///         "error": null
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Returns the requested student</response>
        /// <response code="404">If the student is not found</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var result = await Mediator.Send(new GetStudentByIdQuery { Id = id });
            return CreateResponse(result);
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>List of all students.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/students
        /// 
        /// Sample response:
        /// 
        ///     {
        ///         "data": [
        ///             {
        ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///                 "firstName": "John",
        ///                 "lastName": "Doe",
        ///                 "email": "john.doe@example.com"
        ///             },
        ///             {
        ///                 "id": "8a1b9c3d-4e5f-6g7h-8i9j-0k1l2m3n4o5p",
        ///                 "firstName": "Jane",
        ///                 "lastName": "Smith",
        ///                 "email": "jane.smith@example.com"
        ///             }
        ///         ],
        ///         "message": "Students retrieved successfully.",
        ///         "statusCode": 200,
        ///         "error": null
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Returns the list of students</response>
        [Authorize(Roles = "Admin,Instructor")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await Mediator.Send(new GetAllStudentsQuery());
            return CreateResponse(result);
        }

        /// <summary>
        /// Updates an existing student.
        /// </summary>
        /// <param name="id">The id of the student to update.</param>
        /// <param name="command">The update student command.</param>
        /// <returns>The updated student.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/students/3fa85f64-5717-4562-b3fc-2c963f66afa6
        ///     {
        ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "firstName": "John",
        ///         "lastName": "Smith",
        ///         "email": "john.smith@example.com"
        ///     }
        /// 
        /// Sample response:
        /// 
        ///     {
        ///         "data": {
        ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///             "firstName": "John",
        ///             "lastName": "Smith",
        ///             "email": "john.smith@example.com"
        ///         },
        ///         "message": "Student updated successfully.",
        ///         "statusCode": 200,
        ///         "error": null
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Returns the updated student</response>
        /// <response code="400">If the item is null or invalid</response>
        /// <response code="404">If the student is not found</response>
        [Authorize(Roles = "Admin,Student")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] UpdateStudentCommand command)
        {
            if (id != command.Id)
                return BadRequest("The ID in the URL does not match the ID in the request body.");

            var result = await Mediator.Send(command);
            return CreateResponse(result);
        }
    }
}