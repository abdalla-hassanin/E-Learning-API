using ELearningApi.Api.Base;
using ELearningApi.Core.MediatrHandlers.Instructor.Commands.UpdateInstructor;
using ELearningApi.Core.MediatrHandlers.Instructor.Queries.GetAllInstructors;
using ELearningApi.Core.MediatrHandlers.Instructor.Queries.GetInstructorById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Controllers
{
    /// <summary>
    /// Controller for managing instructors.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InstructorsController : AppControllerBase
    {

        /// <summary>
        /// Gets an instructor by id.
        /// </summary>
        /// <param name="id">The id of the instructor.</param>
        /// <returns>The instructor.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/instructors/3fa85f64-5717-4562-b3fc-2c963f66afa6
        /// 
        /// Sample response:
        /// 
        ///     {
        ///         "data": {
        ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///             "firstName": "Jane",
        ///             "lastName": "Doe",
        ///             "email": "jane.doe@example.com",
        ///             "expertise": "Computer Science",
        ///             "biography": "Experienced instructor with 10 years in the field."
        ///         },
        ///         "message": "Instructor retrieved successfully.",
        ///         "statusCode": 200,
        ///         "error": null
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Returns the requested instructor</response>
        /// <response code="404">If the instructor is not found</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructorById(Guid id)
        {
            var result = await Mediator.Send(new GetInstructorByIdQuery { Id = id });
            return CreateResponse(result);
        }

        /// <summary>
        /// Gets all instructors.
        /// </summary>
        /// <returns>List of all instructors.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/instructors
        /// 
        /// Sample response:
        /// 
        ///     {
        ///         "data": [
        ///             {
        ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///                 "firstName": "Jane",
        ///                 "lastName": "Doe",
        ///                 "email": "jane.doe@example.com",
        ///                 "expertise": "Computer Science",
        ///                 "biography": "Experienced instructor with 10 years in the field."
        ///             },
        ///             {
        ///                 "id": "8a1b9c3d-4e5f-6g7h-8i9j-0k1l2m3n4o5p",
        ///                 "firstName": "John",
        ///                 "lastName": "Smith",
        ///                 "email": "john.smith@example.com",
        ///                 "expertise": "Data Science",
        ///                 "biography": "Expert in machine learning and data analysis."
        ///             }
        ///         ],
        ///         "message": "Instructors retrieved successfully.",
        ///         "statusCode": 200,
        ///         "error": null
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Returns the list of instructors</response>
        [HttpGet]
        public async Task<IActionResult> GetAllInstructors()
        {
            var result = await Mediator.Send(new GetAllInstructorsQuery());
            return CreateResponse(result);
        }

        /// <summary>
        /// Updates an existing instructor.
        /// </summary>
        /// <param name="id">The id of the instructor to update.</param>
        /// <param name="command">The update instructor command.</param>
        /// <returns>The updated instructor.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/instructors/3fa85f64-5717-4562-b3fc-2c963f66afa6
        ///     {
        ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "firstName": "Jane",
        ///         "lastName": "Smith",
        ///         "email": "jane.smith@example.com",
        ///         "expertise": "Data Science",
        ///         "biography": "Experienced instructor with 12 years in the field."
        ///     }
        /// 
        /// Sample response:
        /// 
        ///     {
        ///         "data": {
        ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///             "firstName": "Jane",
        ///             "lastName": "Smith",
        ///             "email": "jane.smith@example.com",
        ///             "expertise": "Data Science",
        ///             "biography": "Experienced instructor with 12 years in the field."
        ///         },
        ///         "message": "Instructor updated successfully.",
        ///         "statusCode": 200,
        ///         "error": null
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Returns the updated instructor</response>
        /// <response code="400">If the item is null or invalid</response>
        /// <response code="404">If the instructor is not found</response>
        [Authorize(Roles = "Admin,Instructor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstructor(Guid id, [FromBody] UpdateInstructorCommand command)
        {
            if (id != command.Id)
                return BadRequest("The ID in the URL does not match the ID in the request body.");

            var result = await Mediator.Send(command);
            return CreateResponse(result);
        }

    }
}