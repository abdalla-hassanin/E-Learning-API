// using ELearningApi.Api.Base;
// using ELearningApi.Core.Base.ApiResponse;
// using ELearningApi.Core.MediatrHandlers.Auth;
// using ELearningApi.Core.MediatrHandlers.Auth.ChangePassword;
// using ELearningApi.Core.MediatrHandlers.Auth.ConfirmEmail;
// using ELearningApi.Core.MediatrHandlers.Auth.ForgotPassword;
// using ELearningApi.Core.MediatrHandlers.Auth.Login;
// using ELearningApi.Core.MediatrHandlers.Auth.RefreshToken;
// using ELearningApi.Core.MediatrHandlers.Auth.RegisterInstructor;
// using ELearningApi.Core.MediatrHandlers.Auth.RegisterStudent;
// using ELearningApi.Core.MediatrHandlers.Auth.ResendEmailConfirmation;
// using ELearningApi.Core.MediatrHandlers.Auth.ResetPassword;
// using ELearningApi.Core.MediatrHandlers.Auth.RevokeToken;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ELearningApi.Api.Controllers;
//
// /// <summary>
// /// Controller for handling authentication and authorization operations.
// /// </summary>
// [ApiController]
// [Route("api/[controller]")]
// public class AuthController : AppControllerBase
// {
//     /// <summary>
//     /// Register a new student.
//     /// </summary>
//     /// <param name="command">The registration details for the student.</param>
//     /// <returns>A response containing the authentication result.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     POST /api/Auth/register-student
//     ///     {
//     ///         "email": "student@example.com",
//     ///         "password": "StrongPass123!",
//     ///         "firstName": "John",
//     ///         "lastName": "Doe"
//     ///     }
//     /// 
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Student registered successfully. Please check your email to confirm your account.",
//     ///         "data": {
//     ///             "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
//     ///             "refreshToken": "6ce32ced-c327-4e5c-9d57-7582f7deee24",
//     ///             "tokenExpiration": "2023-06-15T14:30:00Z"
//     ///         }
//     ///     }
//     /// 
//     /// </remarks>
//     /// <response code="200">Returns the authentication result if registration is successful.</response>
//     /// <response code="400">If the registration fails due to invalid input.</response>
//     [HttpPost("register-student")]
//     public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Register a new instructor.
//     /// </summary>
//     /// <param name="command">The registration details for the instructor.</param>
//     /// <returns>A response containing the authentication result.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     POST /api/Auth/register-instructor
//     ///     {
//     ///         "email": "instructor@example.com",
//     ///         "password": "StrongPass123!",
//     ///         "firstName": "Jane",
//     ///         "lastName": "Smith",
//     ///         "expertise": "Computer Science",
//     ///         "biography": "Experienced instructor with 10 years in the field."
//     ///     }
//     /// 
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Instructor registered successfully. Please check your email to confirm your account.",
//     ///         "data": {
//     ///             "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
//     ///             "refreshToken": "7de43def-d328-5f6d-0e68-8693g8eff35",
//     ///             "tokenExpiration": "2023-06-15T14:30:00Z"
//     ///         }
//     ///     }
//     /// 
//     /// </remarks>
//     /// <response code="200">Returns the authentication result if registration is successful.</response>
//     /// <response code="400">If the registration fails due to invalid input.</response>
//     [HttpPost("register-instructor")]
//     public async Task<IActionResult> RegisterInstructor([FromBody] RegisterInstructorCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Authenticate a user and return a JWT token.
//     /// </summary>
//     /// <param name="command">The login credentials.</param>
//     /// <returns>A response containing the authentication result with JWT token.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     POST /api/Auth/login
//     ///     {
//     ///         "email": "user@example.com",
//     ///         "password": "StrongPass123!"
//     ///     }
//     /// 
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Login successful",
//     ///         "data": {
//     ///             "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
//     ///             "refreshToken": "8ef54fgh-e439-6g7h-1f79-9704h9fgg46",
//     ///             "tokenExpiration": "2023-06-15T16:30:00Z"
//     ///         }
//     ///     }
//     /// 
//     /// </remarks>
//     /// <response code="200">Returns the authentication result with JWT token if login is successful.</response>
//     /// <response code="401">If the login fails due to invalid credentials.</response>
//     [HttpPost("login")]
//     public async Task<IActionResult> Login([FromBody] LoginCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Refresh the JWT token using a refresh token.
//     /// </summary>
//     /// <param name="command">The refresh token command containing the current access token and refresh token.</param>
//     /// <returns>A response containing the new JWT token and refresh token.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     POST /api/Auth/refresh-token
//     ///     {
//     ///         "accessToken": "eyJhbGciOiJIUzI1NiIsInR5...",
//     ///         "refreshToken": "6ce32ced-c327-4e5c-9d57-..."
//     ///     }
//     /// 
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Token refreshed successfully",
//     ///         "data": {
//     ///             "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
//     ///             "refreshToken": "9fg65hij-f540-7i8j-2g80-0815i0ghh57",
//     ///             "tokenExpiration": "2023-06-15T18:30:00Z"
//     ///         }
//     ///     }
//     /// 
//     /// </remarks>
//     /// <response code="200">Returns the new JWT token and refresh token if refresh is successful.</response>
//     /// <response code="401">If the refresh token is invalid or expired.</response>
//     [HttpPost("refresh-token")]
//     public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Revoke the refresh token for a user.
//     /// </summary>
//     /// <param name="command">The command containing the username of the user whose token should be revoked.</param>
//     /// <returns>A response indicating the success of the operation.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     POST /api/Auth/revoke-token
//     ///     {
//     ///         "username": "user@example.com"
//     ///     }
//     /// 
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Token revoked successfully",
//     ///         "data": null
//     ///     }
//     /// 
//     /// </remarks>
//     /// <response code="200">Returns a success message if the token was revoked.</response>
//     /// <response code="400">If the username is invalid or not found.</response>
//     [Authorize]
//     [HttpPost("revoke-token")]
//     public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Initiate the forgot password process for a user.
//     /// </summary>
//     /// <param name="command">The command containing the email of the user who forgot their password.</param>
//     /// <returns>A response indicating that a password reset email has been sent if the email exists.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     POST /api/Auth/forgot-password
//     ///     {
//     ///         "email": "user@example.com"
//     ///     }
//     /// 
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "If that email address is in our system, we have sent a password reset link to it.",
//     ///         "data": null
//     ///     }
//     /// 
//     /// </remarks>
//     /// <response code="200">Returns a success message indicating that a password reset email has been sent (if the email exists).</response>
//     [HttpPost("forgot-password")]
//     public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Reset a user's password using a reset token.
//     /// </summary>
//     /// <param name="command">The command containing the email, reset token, and new password.</param>
//     /// <returns>A response indicating the success of the password reset operation.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     POST /api/Auth/reset-password
//     ///     {
//     ///         "email": "user@example.com",
//     ///         "token": "CfDJ8NrQMN9ZrPJkwh...",
//     ///         "newPassword": "NewStrongPass123!"
//     ///     }
//     /// 
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Password has been reset successfully.",
//     ///         "data": null
//     ///     }
//     /// 
//     /// </remarks>
//     /// <response code="200">Returns a success message if the password was reset successfully.</response>
//     /// <response code="400">If the reset token is invalid or expired.</response>
//     [HttpPost("reset-password")]
//     public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Change the password for an authenticated user.
//     /// </summary>
//     /// <param name="command">The command containing the username, current password, and new password.</param>
//     /// <returns>A response indicating the success of the password change operation.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     POST /api/Auth/change-password
//     ///     {
//     ///         "username": "user@example.com",
//     ///         "currentPassword": "OldStrongPass123!",
//     ///         "newPassword": "NewStrongPass123!"
//     ///     }
//     /// 
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Password changed successfully.",
//     ///         "data": null
//     ///     }
//     /// 
//     /// </remarks>
//     /// <response code="200">Returns a success message if the password was changed successfully.</response>
//     /// <response code="400">If the current password is incorrect or the new password is invalid.</response>
//     [Authorize]
//     [HttpPost("change-password")]
//     public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Confirm a user's email address using a confirmation token.
//     /// </summary>
//     /// <param name="command">The command containing the user ID and confirmation token.</param>
//     /// <returns>A response indicating the success of the email confirmation.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     POST /api/Auth/confirm-email
//     ///     {
//     ///         "userId": "123e4567-e89b-12d3-a456-426614174000",
//     ///         "token": "CfDJ8NrQMN9ZrPJkwh..."
//     ///     }
//     /// 
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Thank you for confirming your email.",
//     ///         "data": null
//     ///     }
//     /// 
//     /// </remarks>
//     /// <response code="200">Returns a success message if the email was confirmed successfully.</response>
//     /// <response code="400">If the confirmation token is invalid or expired.</response>
//     [HttpPost("confirm-email")]
//     public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Resend the email confirmation link to a user.
//     /// </summary>
//     /// <param name="command">The command containing the email address to resend the confirmation to.</param>
//     /// <returns>A response indicating that the confirmation email has been resent.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     POST /api/Auth/resend-email-confirmation
//     ///     {
//     ///         "email": "user@example.com"
//     ///     }
//     /// 
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Verification email sent. Please check your email.",
//     ///         "data": null
//     ///     }
//     /// 
//     /// </remarks>
//     /// <response code="200">Returns a success message indicating that the confirmation email has been resent.</response>
//     /// <response code="400">If the email is already confirmed or not found.</response>
//     [HttpPost("resend-email-confirmation")]
//     public async Task<IActionResult> ResendEmailConfirmation([FromBody] ResendEmailConfirmationCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
// }using ELearningApi.Api.Base;
// using ELearningApi.Core.MediatrHandlers.Category.Commands.CreateCategory;
// using ELearningApi.Core.MediatrHandlers.Category.Commands.DeleteCategory;
// using ELearningApi.Core.MediatrHandlers.Category.Commands.UpdateCategory;
// using ELearningApi.Core.MediatrHandlers.Category.Queries.GetAllCategories;
// using ELearningApi.Core.MediatrHandlers.Category.Queries.GetCategoryById;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ELearningApi.Api.Controllers;
//
// /// <summary>
// /// Controller for managing categories in the e-learning system.
// /// </summary>
// [ApiController]
// [Route("api/[controller]")]
// public class CategoryController : AppControllerBase
// {
//     /// <summary>
//     /// Creates a new category.
//     /// </summary>
//     /// <param name="command">The create category command.</param>
//     /// <returns>The newly created category.</returns>
//     /// <response code="201">Returns the newly created category.</response>
//     /// <response code="400">If the command is invalid.</response>
//     /// <response code="500">If there was an internal server error.</response>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     POST /api/Category
//     ///     {
//     ///        "name": "Programming"
//     ///     }
//     ///
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 201,
//     ///         "succeeded": true,
//     ///         "message": "Category created successfully",
//     ///         "errors": [],
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "name": "Programming",
//     ///             "courseCount": 0
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPost]
//     public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves a specific category by id.
//     /// </summary>
//     /// <param name="id">The id of the category to retrieve.</param>
//     /// <returns>The requested category.</returns>
//     /// <response code="200">Returns the requested category.</response>
//     /// <response code="404">If the category is not found.</response>
//     /// <response code="500">If there was an internal server error.</response>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     GET /api/Category/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": null,
//     ///         "errors": [],
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "name": "Programming",
//     ///             "courseCount": 5
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor,Student")] 
//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetCategory(Guid id)
//     {
//         var result = await Mediator.Send(new GetCategoryByIdQuery { Id = id });
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves all categories.
//     /// </summary>
//     /// <returns>A list of all categories.</returns>
//     /// <response code="200">Returns the list of categories.</response>
//     /// <response code="500">If there was an internal server error.</response>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     GET /api/Category
//     ///
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": null,
//     ///         "errors": [],
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "name": "Programming",
//     ///                 "courseCount": 5
//     ///             },
//     ///             {
//     ///                 "id": "8a1b22c3-9d3e-4f5g-6h7i-8j9k0l1m2n3o",
//     ///                 "name": "Data Science",
//     ///                 "courseCount": 3
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor,Student")] 
//     [HttpGet]
//     public async Task<IActionResult> GetAllCategories()
//     {
//         var result = await Mediator.Send(new GetAllCategoriesQuery());
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Updates an existing category.
//     /// </summary>
//     /// <param name="command">The update category command.</param>
//     /// <returns>The updated category.</returns>
//     /// <response code="200">Returns the updated category.</response>
//     /// <response code="400">If the command is invalid.</response>
//     /// <response code="404">If the category is not found.</response>
//     /// <response code="500">If there was an internal server error.</response>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     PUT /api/Category
//     ///     {
//     ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///         "name": "Advanced Programming"
//     ///     }
//     ///
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Category updated successfully",
//     ///         "errors": [],
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "name": "Advanced Programming",
//     ///             "courseCount": 5
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin")]
//     [HttpPut]
//     public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Deletes a specific category.
//     /// </summary>
//     /// <param name="id">The id of the category to delete.</param>
//     /// <returns>A success message.</returns>
//     /// <response code="200">If the category was successfully deleted.</response>
//     /// <response code="404">If the category is not found.</response>
//     /// <response code="500">If there was an internal server error.</response>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     DELETE /api/Category/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Category deleted successfully",
//     ///         "errors": [],
//     ///         "data": null
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin")]
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteCategory(Guid id)
//     {
//         var result = await Mediator.Send(new DeleteCategoryCommand { Id = id });
//         return CreateResponse(result);
//     }
// }using ELearningApi.Api.Base;
// using ELearningApi.Core.Base.ApiResponse;
// using ELearningApi.Core.MediatrHandlers.Course;
// using ELearningApi.Core.MediatrHandlers.Course.Commands.CreateCourse;
// using ELearningApi.Core.MediatrHandlers.Course.Commands.DeleteCourse;
// using ELearningApi.Core.MediatrHandlers.Course.Commands.UpdateCourse;
// using ELearningApi.Core.MediatrHandlers.Course.Queries.GetCourseById;
// using ELearningApi.Core.MediatrHandlers.Course.Queries.GetCourseRating;
// using ELearningApi.Core.MediatrHandlers.Course.Queries.GetCoursesByCategory;
// using ELearningApi.Core.MediatrHandlers.Course.Queries.GetCoursesByInstructor;
// using ELearningApi.Core.MediatrHandlers.Course.Queries.SearchCourses;
// using ELearningApi.Data.Enums;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ELearningApi.Api.Controllers;
//
// /// <summary>
// /// Controller for managing courses in the e-learning system.
// /// </summary>
// [ApiController]
// [Route("api/[controller]")]
// [Authorize] 
// public class CourseController : AppControllerBase
// {
//     /// <summary>
//     /// Creates a new course.
//     /// </summary>
//     /// <param name="command">The course creation command.</param>
//     /// <returns>The created course.</returns>
//     /// <response code="201">Returns the newly created course</response>
//     /// <response code="400">If the course data is invalid</response>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/Course
//     ///     {
//     ///        "title": "Introduction to C#",
//     ///        "description": "Learn the basics of C# programming",
//     ///        "shortDescription": "Start your C# journey",
//     ///        "price": 49.99,
//     ///        "instructorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///        "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///        "thumbnailUrl": "https://example.com/thumbnail.jpg",
//     ///        "trailerVideoUrl": "https://example.com/trailer.mp4",
//     ///        "level": "Beginner",
//     ///        "prerequisites": ["Basic programming knowledge"],
//     ///        "learningObjectives": ["Understand C# syntax", "Write simple C# programs"],
//     ///        "estimatedDuration": "10:00:00"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///        "statusCode": 201,
//     ///        "succeeded": true,
//     ///        "message": "Course created successfully",
//     ///        "data": {
//     ///           "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///           "title": "Introduction to C#",
//     ///           "description": "Learn the basics of C# programming",
//     ///           "shortDescription": "Start your C# journey",
//     ///           "price": 49.99,
//     ///           "instructorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///           "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///           "thumbnailUrl": "https://example.com/thumbnail.jpg",
//     ///           "trailerVideoUrl": "https://example.com/trailer.mp4",
//     ///           "level": "Beginner",
//     ///           "prerequisites": ["Basic programming knowledge"],
//     ///           "learningObjectives": ["Understand C# syntax", "Write simple C# programs"],
//     ///           "estimatedDuration": "10:00:00",
//     ///           "createdAt": "2023-06-01T12:00:00Z",
//     ///           "updatedAt": "2023-06-01T12:00:00Z"
//     ///        }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPost]
//     public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves a specific course by id.
//     /// </summary>
//     /// <param name="id">The id of the course to retrieve.</param>
//     /// <returns>The requested course.</returns>
//     /// <response code="200">Returns the requested course</response>
//     /// <response code="404">If the course is not found</response>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Course/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///        "statusCode": 200,
//     ///        "succeeded": true,
//     ///        "data": {
//     ///           "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///           "title": "Introduction to C#",
//     ///           "description": "Learn the basics of C# programming",
//     ///           "shortDescription": "Start your C# journey",
//     ///           "price": 49.99,
//     ///           "instructorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///           "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///           "thumbnailUrl": "https://example.com/thumbnail.jpg",
//     ///           "trailerVideoUrl": "https://example.com/trailer.mp4",
//     ///           "level": "Beginner",
//     ///           "prerequisites": ["Basic programming knowledge"],
//     ///           "learningObjectives": ["Understand C# syntax", "Write simple C# programs"],
//     ///           "estimatedDuration": "10:00:00",
//     ///           "createdAt": "2023-06-01T12:00:00Z",
//     ///           "updatedAt": "2023-06-01T12:00:00Z"
//     ///        }
//     ///     }
//     /// </remarks>
//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetCourse(Guid id)
//     {
//         var result = await Mediator.Send(new GetCourseByIdQuery { Id = id });
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Updates an existing course.
//     /// </summary>
//     /// <param name="id">The id of the course to update.</param>
//     /// <param name="command">The course update command.</param>
//     /// <returns>The updated course.</returns>
//     /// <response code="200">Returns the updated course</response>
//     /// <response code="400">If the course data is invalid</response>
//     /// <response code="404">If the course is not found</response>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     PUT /api/Course/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///     {
//     ///        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///        "title": "Advanced C# Programming",
//     ///        "description": "Take your C# skills to the next level",
//     ///        "price": 79.99,
//     ///        "level": "Intermediate"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///        "statusCode": 200,
//     ///        "succeeded": true,
//     ///        "message": "Course updated successfully",
//     ///        "data": {
//     ///           "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///           "title": "Advanced C# Programming",
//     ///           "description": "Take your C# skills to the next level",
//     ///           "price": 79.99,
//     ///           "level": "Intermediate",
//     ///           "updatedAt": "2023-06-02T10:30:00Z"
//     ///        }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPut("{id}")]
//     public async Task<IActionResult> UpdateCourse(Guid id, [FromBody] UpdateCourseCommand command)
//     {
//         if (id != command.Id)
//             return BadRequest(new ApiResponse<CourseDto> { Succeeded = false, Message = "ID mismatch" });
//
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Deletes a specific course.
//     /// </summary>
//     /// <param name="id">The id of the course to delete.</param>
//     /// <returns>A success message.</returns>
//     /// <response code="200">If the course was successfully deleted</response>
//     /// <response code="404">If the course is not found</response>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     DELETE /api/Course/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///        "statusCode": 200,
//     ///        "succeeded": true,
//     ///        "message": "Course deleted successfully"
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteCourse(Guid id)
//     {
//         var result = await Mediator.Send(new DeleteCourseCommand { Id = id });
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves courses by category.
//     /// </summary>
//     /// <param name="categoryId">The id of the category.</param>
//     /// <returns>A list of courses in the specified category.</returns>
//     /// <response code="200">Returns the list of courses</response>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Course/category/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///        "statusCode": 200,
//     ///        "succeeded": true,
//     ///        "data": [
//     ///           {
//     ///              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///              "title": "Introduction to C#",
//     ///              "shortDescription": "Start your C# journey",
//     ///              "price": 49.99,
//     ///              "level": "Beginner"
//     ///           },
//     ///           {
//     ///              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///              "title": "Advanced C# Programming",
//     ///              "shortDescription": "Take your C# skills to the next level",
//     ///              "price": 79.99,
//     ///              "level": "Intermediate"
//     ///           }
//     ///        ]
//     ///     }
//     /// </remarks>
//     [HttpGet("category/{categoryId}")]
//     public async Task<IActionResult> GetCoursesByCategory(Guid categoryId)
//     {
//         var result = await Mediator.Send(new GetCoursesByCategoryQuery { CategoryId = categoryId });
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves courses by instructor.
//     /// </summary>
//     /// <param name="instructorId">The id of the instructor.</param>
//     /// <returns>A list of courses by the specified instructor.</returns>
//     /// <response code="200">Returns the list of courses</response>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Course/instructor/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///        "statusCode": 200,
//     ///        "succeeded": true,
//     ///        "data": [
//     ///           {
//     ///              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///              "title": "Introduction to C#",
//     ///              "shortDescription": "Start your C# journey",
//     ///              "price": 49.99,
//     ///              "level": "Beginner"
//     ///           },
//     ///           {
//     ///              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///              "title": "Advanced C# Programming",
//     ///              "shortDescription": "Take your C# skills to the next level",
//     ///              "price": 79.99,
//     ///              "level": "Intermediate"
//     ///           }
//     ///        ]
//     ///     }
//     /// </remarks>
//     [HttpGet("instructor/{instructorId}")]
//     public async Task<IActionResult> GetCoursesByInstructor(Guid instructorId)
//     {
//         var result = await Mediator.Send(new GetCoursesByInstructorQuery { InstructorId = instructorId });
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Searches for courses based on various criteria.
//     /// </summary>
//     /// <param name="searchTerm">The search term to filter courses.</param>
//     /// <param name="pageNumber">The page number for pagination.</param>
//     /// <param name="pageSize">The page size for pagination.</param>
//     /// <param name="level">The course level to filter by (optional).</param>
//     /// <param name="categoryId">The category id to filter by (optional).</param>
//     /// <returns>A paginated list of courses matching the search criteria.</returns>
//     /// <response code="200">Returns the list of courses</response>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Course/search?searchTerm=C%23&amp;pageNumber=1&amp;pageSize=10&amp;level=Beginner&amp;categoryId=3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///        "statusCode": 200,
//     ///        "succeeded": true,
//     ///        "data": {
//     ///           "courses": [
//     ///              {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "title": "Introduction to C#",
//     ///                 "shortDescription": "Start your C# journey",
//     ///                 "price": 49.99,
//     ///                 "level": "Beginner"
//     ///              },
//     ///              {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "title": "C# for Beginners",
//     ///                 "shortDescription": "Learn C# from scratch",
//     ///                 "price": 39.99,
//     ///                 "level": "Beginner"
//     ///              }
//     ///           ],
//     ///           "totalCount": 2
//     ///        }
//     ///     }
//     /// </remarks>
//     [HttpGet("search")]
//     public async Task<IActionResult> SearchCourses(
//         [FromQuery] string searchTerm,
//         [FromQuery] int pageNumber = 1,
//         [FromQuery] int pageSize = 10,
//         [FromQuery] CourseLevel? level = null,
//         [FromQuery] Guid? categoryId = null)
//     {
//         var query = new SearchCoursesQuery
//         {
//             SearchTerm = searchTerm,
//             PageNumber = pageNumber,
//             PageSize = pageSize,
//             Level = level,
//             CategoryId = categoryId
//         };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves the rating for a specific course.
//     /// </summary>
//     /// <param name="courseId">The id of the course.</param>
//     /// <returns>The course rating.</returns>
//     /// <response code="200">Returns the course rating</response>
//     /// <response code="404">If the course is not found</response>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Course/3fa85f64-5717-4562-b3fc-2c963f66afa6/rating
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///        "statusCode": 200,
//     ///        "succeeded": true,
//     ///        "data": "4.5"
//     ///     }
//     /// </remarks>
//     [HttpGet("{courseId}/rating")]
//     public async Task<IActionResult> GetCourseRating(Guid courseId)
//     {
//         var result = await Mediator.Send(new GetCourseRatingQuery { CourseId = courseId });
//         return CreateResponse(result);
//     }
// }using ELearningApi.Api.Base;
// using ELearningApi.Core.MediatrHandlers.Enrollment.Commands.EnrollStudentInCourse;
// using ELearningApi.Core.MediatrHandlers.Enrollment.Commands.UnEnrollStudentFromCourse;
// using ELearningApi.Core.MediatrHandlers.Enrollment.Commands.UpdateEnrollmentStatus;
// using ELearningApi.Core.MediatrHandlers.Enrollment.Queries.CheckEnrollmentStatus;
// using ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentById;
// using ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentsForCourse;
// using ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentsForStudent;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ELearningApi.Api.Controllers;
//
// /// <summary>
// /// Controller for managing student enrollments in courses.
// /// </summary>
// [ApiController]
// [Route("api/[controller]")]
// [Authorize] 
// public class EnrollmentController : AppControllerBase
// {
//     /// <summary>
//     /// Enrolls a student in a course.
//     /// </summary>
//     /// <param name="command">The enrollment command containing StudentId and CourseId.</param>
//     /// <returns>The created enrollment details.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     POST /api/Enrollment
//     ///     {
//     ///         "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ///     }
//     ///
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 201,
//     ///         "succeeded": true,
//     ///         "message": "Student enrolled successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "enrolledAt": "2023-06-07T10:00:00Z",
//     ///             "status": "Enrolled",
//     ///             "progress": 0
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Student")]
//     [HttpPost]
//     public async Task<IActionResult> EnrollStudentInCourse([FromBody] EnrollStudentInCourseCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Unenrolls a student from a course.
//     /// </summary>
//     /// <param name="command">The unenrollment command containing StudentId and CourseId.</param>
//     /// <returns>A success message if the unenrollment is successful.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     DELETE /api/Enrollment
//     ///     {
//     ///         "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ///     }
//     ///
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Student unEnrolled successfully.",
//     ///         "data": "Student unEnrolled successfully."
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Student")]
//     [HttpDelete]
//     public async Task<IActionResult> UnEnrollStudentFromCourse([FromBody] UnEnrollStudentFromCourseCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Updates the status of an enrollment.
//     /// </summary>
//     /// <param name="command">The update command containing EnrollmentId and NewStatus.</param>
//     /// <returns>The updated enrollment details.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     PUT /api/Enrollment
//     ///     {
//     ///         "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///         "newStatus": "Completed"
//     ///     }
//     ///
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Enrollment status updated successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "enrolledAt": "2023-06-07T10:00:00Z",
//     ///             "completedAt": "2023-06-14T15:30:00Z",
//     ///             "status": "Completed",
//     ///             "progress": 100
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPut]
//     public async Task<IActionResult> UpdateEnrollmentStatus([FromBody] UpdateEnrollmentStatusCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Checks the enrollment status of a student for a specific course.
//     /// </summary>
//     /// <param name="studentId">The ID of the student.</param>
//     /// <param name="courseId">The ID of the course.</param>
//     /// <returns>The enrollment status (true if enrolled, false otherwise).</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     GET /api/Enrollment/status?studentId=3fa85f64-5717-4562-b3fc-2c963f66afa6&amp;courseId=3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": "True"
//     ///     }
//     /// </remarks>
//     [HttpGet("status")]
//     public async Task<IActionResult> CheckEnrollmentStatus([FromQuery] Guid studentId, [FromQuery] Guid courseId)
//     {
//         var query = new CheckEnrollmentStatusQuery { StudentId = studentId, CourseId = courseId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves an enrollment by its ID.
//     /// </summary>
//     /// <param name="id">The ID of the enrollment.</param>
//     /// <returns>The enrollment details.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     GET /api/Enrollment/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "enrolledAt": "2023-06-07T10:00:00Z",
//     ///             "completedAt": null,
//     ///             "status": "InProgress",
//     ///             "progress": 50
//     ///         }
//     ///     }
//     /// </remarks>
//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetEnrollmentById(Guid id)
//     {
//         var query = new GetEnrollmentByIdQuery { EnrollmentId = id };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves all enrollments for a specific course.
//     /// </summary>
//     /// <param name="courseId">The ID of the course.</param>
//     /// <returns>A list of enrollments for the specified course.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     GET /api/Enrollment/course/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "enrolledAt": "2023-06-07T10:00:00Z",
//     ///                 "completedAt": null,
//     ///                 "status": "InProgress",
//     ///                 "progress": 50
//     ///             },
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "enrolledAt": "2023-06-08T09:00:00Z",
//     ///                 "completedAt": null,
//     ///                 "status": "Enrolled",
//     ///                 "progress": 0
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpGet("course/{courseId}")]
//     public async Task<IActionResult> GetEnrollmentsForCourse(Guid courseId)
//     {
//         var query = new GetEnrollmentsForCourseQuery { CourseId = courseId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves all enrollments for a specific student.
//     /// </summary>
//     /// <param name="studentId">The ID of the student.</param>
//     /// <returns>A list of enrollments for the specified student.</returns>
//     /// <remarks>
//     /// Sample request:
//     /// 
//     ///     GET /api/Enrollment/student/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     /// 
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "enrolledAt": "2023-06-07T10:00:00Z",
//     ///                 "completedAt": null,
//     ///                 "status": "InProgress",
//     ///                 "progress": 50
//     ///             },
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "enrolledAt": "2023-06-08T09:00:00Z",
//     ///                 "completedAt": "2023-06-15T14:30:00Z",
//     ///                 "status": "Completed",
//     ///                 "progress": 100
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("student/{studentId}")]
//     public async Task<IActionResult> GetEnrollmentsForStudent(Guid studentId)
//     {
//         var query = new GetEnrollmentsForStudentQuery { StudentId = studentId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
// }using ELearningApi.Api.Base;
// using ELearningApi.Core.MediatrHandlers.Instructor.Commands.UpdateInstructor;
// using ELearningApi.Core.MediatrHandlers.Instructor.Queries.GetAllInstructors;
// using ELearningApi.Core.MediatrHandlers.Instructor.Queries.GetInstructorById;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ELearningApi.Api.Controllers
// {
//     /// <summary>
//     /// Controller for managing instructors.
//     /// </summary>
//     [Route("api/[controller]")]
//     [ApiController]
//     [Authorize]
//     public class InstructorsController : AppControllerBase
//     {
//
//         /// <summary>
//         /// Gets an instructor by id.
//         /// </summary>
//         /// <param name="id">The id of the instructor.</param>
//         /// <returns>The instructor.</returns>
//         /// <remarks>
//         /// Sample request:
//         /// 
//         ///     GET /api/instructors/3fa85f64-5717-4562-b3fc-2c963f66afa6
//         /// 
//         /// Sample response:
//         /// 
//         ///     {
//         ///         "data": {
//         ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         ///             "firstName": "Jane",
//         ///             "lastName": "Doe",
//         ///             "email": "jane.doe@example.com",
//         ///             "expertise": "Computer Science",
//         ///             "biography": "Experienced instructor with 10 years in the field."
//         ///         },
//         ///         "message": "Instructor retrieved successfully.",
//         ///         "statusCode": 200,
//         ///         "error": null
//         ///     }
//         /// 
//         /// </remarks>
//         /// <response code="200">Returns the requested instructor</response>
//         /// <response code="404">If the instructor is not found</response>
//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetInstructorById(Guid id)
//         {
//             var result = await Mediator.Send(new GetInstructorByIdQuery { Id = id });
//             return CreateResponse(result);
//         }
//
//         /// <summary>
//         /// Gets all instructors.
//         /// </summary>
//         /// <returns>List of all instructors.</returns>
//         /// <remarks>
//         /// Sample request:
//         /// 
//         ///     GET /api/instructors
//         /// 
//         /// Sample response:
//         /// 
//         ///     {
//         ///         "data": [
//         ///             {
//         ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         ///                 "firstName": "Jane",
//         ///                 "lastName": "Doe",
//         ///                 "email": "jane.doe@example.com",
//         ///                 "expertise": "Computer Science",
//         ///                 "biography": "Experienced instructor with 10 years in the field."
//         ///             },
//         ///             {
//         ///                 "id": "8a1b9c3d-4e5f-6g7h-8i9j-0k1l2m3n4o5p",
//         ///                 "firstName": "John",
//         ///                 "lastName": "Smith",
//         ///                 "email": "john.smith@example.com",
//         ///                 "expertise": "Data Science",
//         ///                 "biography": "Expert in machine learning and data analysis."
//         ///             }
//         ///         ],
//         ///         "message": "Instructors retrieved successfully.",
//         ///         "statusCode": 200,
//         ///         "error": null
//         ///     }
//         /// 
//         /// </remarks>
//         /// <response code="200">Returns the list of instructors</response>
//         [HttpGet]
//         public async Task<IActionResult> GetAllInstructors()
//         {
//             var result = await Mediator.Send(new GetAllInstructorsQuery());
//             return CreateResponse(result);
//         }
//
//         /// <summary>
//         /// Updates an existing instructor.
//         /// </summary>
//         /// <param name="id">The id of the instructor to update.</param>
//         /// <param name="command">The update instructor command.</param>
//         /// <returns>The updated instructor.</returns>
//         /// <remarks>
//         /// Sample request:
//         /// 
//         ///     PUT /api/instructors/3fa85f64-5717-4562-b3fc-2c963f66afa6
//         ///     {
//         ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         ///         "firstName": "Jane",
//         ///         "lastName": "Smith",
//         ///         "email": "jane.smith@example.com",
//         ///         "expertise": "Data Science",
//         ///         "biography": "Experienced instructor with 12 years in the field."
//         ///     }
//         /// 
//         /// Sample response:
//         /// 
//         ///     {
//         ///         "data": {
//         ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         ///             "firstName": "Jane",
//         ///             "lastName": "Smith",
//         ///             "email": "jane.smith@example.com",
//         ///             "expertise": "Data Science",
//         ///             "biography": "Experienced instructor with 12 years in the field."
//         ///         },
//         ///         "message": "Instructor updated successfully.",
//         ///         "statusCode": 200,
//         ///         "error": null
//         ///     }
//         /// 
//         /// </remarks>
//         /// <response code="200">Returns the updated instructor</response>
//         /// <response code="400">If the item is null or invalid</response>
//         /// <response code="404">If the instructor is not found</response>
//         [Authorize(Roles = "Admin,Instructor")]
//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateInstructor(Guid id, [FromBody] UpdateInstructorCommand command)
//         {
//             if (id != command.Id)
//                 return BadRequest("The ID in the URL does not match the ID in the request body.");
//
//             var result = await Mediator.Send(command);
//             return CreateResponse(result);
//         }
//
//     }
// }using ELearningApi.Api.Base;
// using ELearningApi.Core.MediatrHandlers.Lecture.Command.AddResourceToLecture;
// using ELearningApi.Core.MediatrHandlers.Lecture.Command.CreateLecture;
// using ELearningApi.Core.MediatrHandlers.Lecture.Command.DeleteLecture;
// using ELearningApi.Core.MediatrHandlers.Lecture.Command.RemoveResourceFromLecture;
// using ELearningApi.Core.MediatrHandlers.Lecture.Command.UpdateLecture;
// using ELearningApi.Core.MediatrHandlers.Lecture.Queries.GetLectureById;
// using ELearningApi.Core.MediatrHandlers.Lecture.Queries.GetLecturesForSection;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ELearningApi.Api.Controllers;
//
// /// <summary>
// /// Controller for managing lectures.
// /// </summary>
// [ApiController]
// [Route("api/[controller]")]
// [Authorize]
// public class LectureController : AppControllerBase
// {
//     /// <summary>
//     /// Creates a new lecture.
//     /// </summary>
//     /// <param name="command">The create lecture command.</param>
//     /// <returns>The created lecture.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/Lecture
//     ///     {
//     ///         "title": "Introduction to C#",
//     ///         "description": "Learn the basics of C# programming",
//     ///         "content": "C# is a modern, object-oriented programming language...",
//     ///         "duration": "01:30:00",
//     ///         "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///         "type": 0,
//     ///         "videoUrl": "https://example.com/video.mp4"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Lecture created successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "title": "Introduction to C#",
//     ///             "description": "Learn the basics of C# programming",
//     ///             "content": "C# is a modern, object-oriented programming language...",
//     ///             "duration": "01:30:00",
//     ///             "orderIndex": 1,
//     ///             "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "type": 0,
//     ///             "videoUrl": "https://example.com/video.mp4",
//     ///             "resources": []
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPost]
//     public async Task<IActionResult> CreateLecture([FromBody] CreateLectureCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves a lecture by its ID.
//     /// </summary>
//     /// <param name="id">The ID of the lecture to retrieve.</param>
//     /// <returns>The requested lecture.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Lecture/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Lecture retrieved successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "title": "Introduction to C#",
//     ///             "description": "Learn the basics of C# programming",
//     ///             "content": "C# is a modern, object-oriented programming language...",
//     ///             "duration": "01:30:00",
//     ///             "orderIndex": 1,
//     ///             "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "type": 0,
//     ///             "videoUrl": "https://example.com/video.mp4",
//     ///             "resources": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                     "title": "C# Cheat Sheet",
//     ///                     "description": "Quick reference for C# syntax",
//     ///                     "url": "https://example.com/csharp-cheatsheet.pdf",
//     ///                     "type": 0
//     ///                 }
//     ///             ]
//     ///         }
//     ///     }
//     /// </remarks>
//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetLectureById(Guid id)
//     {
//         var query = new GetLectureByIdQuery { Id = id };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Updates an existing lecture.
//     /// </summary>
//     /// <param name="id">The ID of the lecture to update.</param>
//     /// <param name="command">The update lecture command.</param>
//     /// <returns>The updated lecture.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     PUT /api/Lecture/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///     {
//     ///         "title": "Advanced C# Concepts",
//     ///         "description": "Explore advanced topics in C# programming",
//     ///         "content": "In this lecture, we'll dive deeper into C# concepts...",
//     ///         "duration": "02:00:00",
//     ///         "orderIndex": 2,
//     ///         "type": 1,
//     ///         "videoUrl": "https://example.com/advanced-csharp.mp4"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Lecture updated successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "title": "Advanced C# Concepts",
//     ///             "description": "Explore advanced topics in C# programming",
//     ///             "content": "In this lecture, we'll dive deeper into C# concepts...",
//     ///             "duration": "02:00:00",
//     ///             "orderIndex": 2,
//     ///             "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "type": 1,
//     ///             "videoUrl": "https://example.com/advanced-csharp.mp4",
//     ///             "resources": []
//     ///         }
//     ///     }
//     /// </remarks>
//     [HttpPut("{id}")]
//     [Authorize(Roles = "Admin,Instructor")]
//     public async Task<IActionResult> UpdateLecture(Guid id, [FromBody] UpdateLectureCommand command)
//     {
//         if (id != command.Id)
//         {
//             return BadRequest("The ID in the URL does not match the ID in the request body.");
//         }
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Deletes a lecture.
//     /// </summary>
//     /// <param name="id">The ID of the lecture to delete.</param>
//     /// <returns>A success message if the lecture was deleted.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     DELETE /api/Lecture/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Lecture deleted successfully.",
//     ///         "data": "Lecture deleted successfully."
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteLecture(Guid id)
//     {
//         var command = new DeleteLectureCommand { Id = id };
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves all lectures for a specific section.
//     /// </summary>
//     /// <param name="sectionId">The ID of the section.</param>
//     /// <returns>A list of lectures in the specified section.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Lecture/section/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Lectures retrieved successfully.",
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "title": "Introduction to C#",
//     ///                 "description": "Learn the basics of C# programming",
//     ///                 "content": "C# is a modern, object-oriented programming language...",
//     ///                 "duration": "01:30:00",
//     ///                 "orderIndex": 1,
//     ///                 "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "type": 0,
//     ///                 "videoUrl": "https://example.com/video.mp4",
//     ///                 "resources": []
//     ///             },
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "title": "Advanced C# Concepts",
//     ///                 "description": "Explore advanced topics in C# programming",
//     ///                 "content": "In this lecture, we'll dive deeper into C# concepts...",
//     ///                 "duration": "02:00:00",
//     ///                 "orderIndex": 2,
//     ///                 "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "type": 1,
//     ///                 "videoUrl": "https://example.com/advanced-csharp.mp4",
//     ///                 "resources": []
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("section/{sectionId}")]
//     public async Task<IActionResult> GetLecturesForSection(Guid sectionId)
//     {
//         var query = new GetLecturesForSectionQuery { SectionId = sectionId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Adds a resource to a lecture.
//     /// </summary>
//     /// <param name="lectureId">The ID of the lecture to add the resource to.</param>
//     /// <param name="command">The add resource command.</param>
//     /// <returns>The updated lecture with the new resource.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/Lecture/3fa85f64-5717-4562-b3fc-2c963f66afa6/resource
//     ///     {
//     ///         "title": "C# Cheat Sheet",
//     ///         "description": "Quick reference for C# syntax",
//     ///         "url": "https://example.com/csharp-cheatsheet.pdf",
//     ///         "type": 0
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Resource added to lecture successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "title": "Introduction to C#",
//     ///             "description": "Learn the basics of C# programming",
//     ///             "content": "C# is a modern, object-oriented programming language...",
//     ///             "duration": "01:30:00",
//     ///             "orderIndex": 1,
//     ///             "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "type": 0,
//     ///             "videoUrl": "https://example.com/video.mp4",
//     ///             "resources": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                     "title": "C# Cheat Sheet",
//     ///                     "description": "Quick reference for C# syntax",
//     ///                     "url": "https://example.com/csharp-cheatsheet.pdf",
//     ///                     "type": 0
//     ///                 }
//     ///             ]
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPost("{lectureId}/resource")]
//     public async Task<IActionResult> AddResourceToLecture(Guid lectureId, [FromBody] AddResourceToLectureCommand command)
//     {
//         if (lectureId != command.LectureId)
//         {
//             return BadRequest("The lecture ID in the URL does not match the lecture ID in the request body.");
//         }
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Removes a resource from a lecture.
//     /// </summary>
//     /// <param name="lectureId">The ID of the lecture to remove the resource from.</param>
//     /// <param name="resourceId">The ID of the resource to remove.</param>
//     /// <returns>The updated lecture without the removed resource.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     DELETE /api/Lecture/3fa85f64-5717-4562-b3fc-2c963f66afa6/resource/3fa85f64-5717-4562-b3fc-2c963f66afa7
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Resource removed from lecture successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "title": "Introduction to C#",
//     ///             "description": "Learn the basics of C# programming",
//     ///             "content": "C# is a modern, object-oriented programming language...",
//     ///             "duration": "01:30:00",
//     ///             "orderIndex": 1,
//     ///             "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "type": 0,
//     ///             "videoUrl": "https://example.com/video.mp4",
//     ///             "resources": []
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpDelete("{lectureId}/resource/{resourceId}")]
//     public async Task<IActionResult> RemoveResourceFromLecture(Guid lectureId, Guid resourceId)
//     {
//         var command = new RemoveResourceFromLectureCommand { LectureId = lectureId, ResourceId = resourceId };
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
// }
// using ELearningApi.Api.Base;
// using ELearningApi.Core.MediatrHandlers.Progress.Commands.MarkLectureComplete;
// using ELearningApi.Core.MediatrHandlers.Progress.Commands.ResetProgress;
// using ELearningApi.Core.MediatrHandlers.Progress.Commands.UpdateProgress;
// using ELearningApi.Core.MediatrHandlers.Progress.Queries.GetCompletedLectures;
// using ELearningApi.Core.MediatrHandlers.Progress.Queries.GetOverallCourseProgress;
// using ELearningApi.Core.MediatrHandlers.Progress.Queries.GetProgressById;
// using ELearningApi.Core.MediatrHandlers.Progress.Queries.GetProgressForEnrollment;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ELearningApi.Api.Controllers;
//
// /// <summary>
// /// Controller for managing student progress.
// /// </summary>
// [ApiController]
// [Route("api/[controller]")]
// [Authorize] 
// public class ProgressController : AppControllerBase
// {
//     /// <summary>
//     /// Updates the progress of a student for a specific lecture.
//     /// </summary>
//     /// <param name="command">The update progress command.</param>
//     /// <returns>The updated progress information.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/Progress/update
//     ///     {
//     ///         "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///         "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///         "progressPercentage": 75,
//     ///         "status": 1
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Progress updated successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///             "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "startedAt": "2023-06-07T10:00:00Z",
//     ///             "completedAt": null,
//     ///             "status": 1,
//     ///             "progressPercentage": 75
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Student")]
//     [HttpPost("update")]
//     public async Task<IActionResult> UpdateProgress([FromBody] UpdateProgressCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Marks a lecture as complete for a student.
//     /// </summary>
//     /// <param name="command">The mark lecture complete command.</param>
//     /// <returns>The updated progress information.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/Progress/complete
//     ///     {
//     ///         "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///         "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Lecture marked as complete.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///             "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "startedAt": "2023-06-07T10:00:00Z",
//     ///             "completedAt": "2023-06-07T11:30:00Z",
//     ///             "status": 2,
//     ///             "progressPercentage": 100
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Student")]
//     [HttpPost("complete")]
//     public async Task<IActionResult> MarkLectureComplete([FromBody] MarkLectureCompleteCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Resets the progress for a student's enrollment.
//     /// </summary>
//     /// <param name="command">The reset progress command.</param>
//     /// <returns>A success message if the progress was reset.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/Progress/reset
//     ///     {
//     ///         "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Progress reset successfully.",
//     ///         "data": "Progress reset successfully."
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPost("reset")]
//     public async Task<IActionResult> ResetProgress([FromBody] ResetProgressCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves the progress for a specific enrollment.
//     /// </summary>
//     /// <param name="enrollmentId">The ID of the enrollment.</param>
//     /// <returns>A list of progress entries for the enrollment.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Progress/enrollment/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///                 "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "startedAt": "2023-06-07T10:00:00Z",
//     ///                 "completedAt": "2023-06-07T11:30:00Z",
//     ///                 "status": 2,
//     ///                 "progressPercentage": 100
//     ///             },
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
//     ///                 "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afb0",
//     ///                 "startedAt": "2023-06-08T09:00:00Z",
//     ///                 "completedAt": null,
//     ///                 "status": 1,
//     ///                 "progressPercentage": 50
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("enrollment/{enrollmentId}")]
//     public async Task<IActionResult> GetProgressForEnrollment(Guid enrollmentId)
//     {
//         var query = new GetProgressForEnrollmentQuery { EnrollmentId = enrollmentId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves the overall course progress for a student.
//     /// </summary>
//     /// <param name="studentId">The ID of the student.</param>
//     /// <param name="courseId">The ID of the course.</param>
//     /// <returns>The overall progress percentage for the course.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Progress/overall?studentId=3fa85f64-5717-4562-b3fc-2c963f66afa6&amp;courseId=3fa85f64-5717-4562-b3fc-2c963f66afa7
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": "75"
//     ///     }
//     /// </remarks>
//     [HttpGet("overall")]
//     public async Task<IActionResult> GetOverallCourseProgress([FromQuery] Guid studentId, [FromQuery] Guid courseId)
//     {
//         var query = new GetOverallCourseProgressQuery { StudentId = studentId, CourseId = courseId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves a list of completed lectures for a student in a course.
//     /// </summary>
//     /// <param name="studentId">The ID of the student.</param>
//     /// <param name="courseId">The ID of the course.</param>
//     /// <returns>A list of completed lectures.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Progress/completed?studentId=3fa85f64-5717-4562-b3fc-2c963f66afa6&amp;courseId=3fa85f64-5717-4562-b3fc-2c963f66afa7
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///                 "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "startedAt": "2023-06-07T10:00:00Z",
//     ///                 "completedAt": "2023-06-07T11:30:00Z",
//     ///                 "status": 2,
//     ///                 "progressPercentage": 100
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("completed")]
//     public async Task<IActionResult> GetCompletedLectures([FromQuery] Guid studentId, [FromQuery] Guid courseId)
//     {
//         var query = new GetCompletedLecturesQuery { StudentId = studentId, CourseId = courseId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves progress details by ID.
//     /// </summary>
//     /// <param name="id">The ID of the progress entry.</param>
//     /// <returns>The progress details for the specified ID.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Progress/3fa85f64-5717-4562-b3fc-2c963f66afa8
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///             "enrollmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "startedAt": "2023-06-07T10:00:00Z",
//     ///             "completedAt": "2023-06-07T11:30:00Z",
//     ///             "status": 2,
//     ///             "progressPercentage": 100
//     ///         }
//     ///     }
//     /// </remarks>
//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetProgressById(Guid id)
//     {
//         var query = new GetProgressByIdQuery { Id = id };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
// }using ELearningApi.Api.Base;
// using ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.CalculateQuizScore;
// using ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.StartQuizAttempt;
// using ELearningApi.Core.MediatrHandlers.QuizAttempt.Commands.SubmitQuizAttempt;
// using ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptHistory;
// using ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptResult;
// using ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptsForQuiz;
// using ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptsForStudent;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ELearningApi.Api.Controllers;
//
// /// <summary>
// /// Controller for quiz attempt operations.
// /// </summary>
// [ApiController]
// [Route("api/[controller]")]
// [Authorize]
// public class QuizAttemptController : AppControllerBase
// {
//     /// <summary>
//     /// Starts a new quiz attempt for a student.
//     /// </summary>
//     /// <param name="command">The start quiz attempt command.</param>
//     /// <returns>The created quiz attempt.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/QuizAttempt/start
//     ///     {
//     ///         "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///         "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Quiz attempt started successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "startTime": "2023-06-07T10:00:00Z",
//     ///             "endTime": null,
//     ///             "score": 0,
//     ///             "isPassed": false,
//     ///             "answers": []
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Student")]
//     [HttpPost("start")]
//     public async Task<IActionResult> StartQuizAttempt([FromBody] StartQuizAttemptCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Submits a quiz attempt with the student's answers.
//     /// </summary>
//     /// <param name="command">The submit quiz attempt command.</param>
//     /// <returns>The submitted quiz attempt with results.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/QuizAttempt/submit
//     ///     {
//     ///         "attemptId": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///         "answers": [
//     ///             {
//     ///                 "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
//     ///                 "response": "3fa85f64-5717-4562-b3fc-2c963f66afaa"
//     ///             },
//     ///             {
//     ///                 "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afab",
//     ///                 "response": "True"
//     ///             }
//     ///         ]
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Quiz attempt submitted successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "startTime": "2023-06-07T10:00:00Z",
//     ///             "endTime": "2023-06-07T10:30:00Z",
//     ///             "score": 75,
//     ///             "isPassed": true,
//     ///             "answers": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afac",
//     ///                     "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
//     ///                     "response": "3fa85f64-5717-4562-b3fc-2c963f66afaa",
//     ///                     "isCorrect": true,
//     ///                     "pointsEarned": 10,
//     ///                     "timeTaken": "00:05:00"
//     ///                 },
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afad",
//     ///                     "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afab",
//     ///                     "response": "True",
//     ///                     "isCorrect": false,
//     ///                     "pointsEarned": 0,
//     ///                     "timeTaken": "00:03:00"
//     ///                 }
//     ///             ]
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Student")]
//     [HttpPost("submit")]
//     public async Task<IActionResult> SubmitQuizAttempt([FromBody] SubmitQuizAttemptCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Calculates the score for a quiz attempt.
//     /// </summary>
//     /// <param name="attemptId">The ID of the quiz attempt.</param>
//     /// <returns>The quiz attempt with calculated score.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/QuizAttempt/3fa85f64-5717-4562-b3fc-2c963f66afa8/calculate-score
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Quiz score calculated successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "startTime": "2023-06-07T10:00:00Z",
//     ///             "endTime": "2023-06-07T10:30:00Z",
//     ///             "score": 75,
//     ///             "isPassed": true,
//     ///             "answers": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afac",
//     ///                     "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
//     ///                     "response": "3fa85f64-5717-4562-b3fc-2c963f66afaa",
//     ///                     "isCorrect": true,
//     ///                     "pointsEarned": 10,
//     ///                     "timeTaken": "00:05:00"
//     ///                 },
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afad",
//     ///                     "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afab",
//     ///                     "response": "True",
//     ///                     "isCorrect": false,
//     ///                     "pointsEarned": 0,
//     ///                     "timeTaken": "00:03:00"
//     ///                 }
//     ///             ]
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPost("{attemptId}/calculate-score")]
//     public async Task<IActionResult> CalculateQuizScore(Guid attemptId)
//     {
//         var command = new CalculateQuizScoreCommand { AttemptId = attemptId };
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves the result of a specific quiz attempt.
//     /// </summary>
//     /// <param name="attemptId">The ID of the quiz attempt.</param>
//     /// <returns>The quiz attempt result.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/QuizAttempt/3fa85f64-5717-4562-b3fc-2c963f66afa8/result
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "startTime": "2023-06-07T10:00:00Z",
//     ///             "endTime": "2023-06-07T10:30:00Z",
//     ///             "score": 75,
//     ///             "isPassed": true,
//     ///             "answers": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afac",
//     ///                     "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
//     ///                     "response": "3fa85f64-5717-4562-b3fc-2c963f66afaa",
//     ///                     "isCorrect": true,
//     ///                     "pointsEarned": 10,
//     ///                     "timeTaken": "00:05:00"
//     ///                 },
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afad",
//     ///                     "questionId": "3fa85f64-5717-4562-b3fc-2c963f66afab",
//     ///                     "response": "True",
//     ///                     "isCorrect": false,
//     ///                     "pointsEarned": 0,
//     ///                     "timeTaken": "00:03:00"
//     ///                 }
//     ///             ]
//     ///         }
//     ///     }
//     /// </remarks>
//     [HttpGet("{attemptId}/result")]
//     public async Task<IActionResult> GetQuizAttemptResult(Guid attemptId)
//     {
//         var query = new GetQuizAttemptResultQuery { AttemptId = attemptId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves all quiz attempts for a specific student and quiz.
//     /// </summary>
//     /// <param name="studentId">The ID of the student.</param>
//     /// <param name="quizId">The ID of the quiz.</param>
//     /// <returns>A list of quiz attempts for the specified student and quiz.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/QuizAttempt/student/3fa85f64-5717-4562-b3fc-2c963f66afa6/quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "startTime": "2023-06-07T10:00:00Z",
//     ///                 "endTime": "2023-06-07T10:30:00Z",
//     ///                 "score": 75,
//     ///                 "isPassed": true,
//     ///                 "answers": []
//     ///             },
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
//     ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "startTime": "2023-06-08T14:00:00Z",
//     ///                 "endTime": "2023-06-08T14:25:00Z",
//     ///                 "score": 90,
//     ///                 "isPassed": true,
//     ///                 "answers": []
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("student/{studentId}/quiz/{quizId}")]
//     public async Task<IActionResult> GetQuizAttemptsForStudent(Guid studentId, Guid quizId)
//     {
//         var query = new GetQuizAttemptsForStudentQuery { StudentId = studentId, QuizId = quizId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves all quiz attempts for a specific quiz.
//     /// </summary>
//     /// <param name="quizId">The ID of the quiz.</param>
//     /// <returns>A list of all quiz attempts for the specified quiz.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/QuizAttempt/quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "startTime": "2023-06-07T10:00:00Z",
//     ///                 "endTime": "2023-06-07T10:30:00Z",
//     ///                 "score": 75,
//     ///                 "isPassed": true,
//     ///                 "answers": []
//     ///             },
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
//     ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afaa",
//     ///                 "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "startTime": "2023-06-08T14:00:00Z",
//     ///                 "endTime": "2023-06-08T14:25:00Z",
//     ///                 "score": 90,
//     ///                 "isPassed": true,
//     ///                 "answers": []
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpGet("quiz/{quizId}")]
//     public async Task<IActionResult> GetQuizAttemptsForQuiz(Guid quizId)
//     {
//         var query = new GetQuizAttemptsForQuizQuery { QuizId = quizId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves the quiz attempt history for a specific student.
//     /// </summary>
//     /// <param name="studentId">The ID of the student.</param>
//     /// <returns>A list of all quiz attempts for the specified student.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/QuizAttempt/history/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "startTime": "2023-06-07T10:00:00Z",
//     ///                 "endTime": "2023-06-07T10:30:00Z",
//     ///                 "score": 75,
//     ///                 "isPassed": true,
//     ///                 "answers": []
//     ///             },
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
//     ///                 "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afab",
//     ///                 "startTime": "2023-06-08T14:00:00Z",
//     ///                 "endTime": "2023-06-08T14:25:00Z",
//     ///                 "score": 90,
//     ///                 "isPassed": true,
//     ///                 "answers": []
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("history/{studentId}")]
//     public async Task<IActionResult> GetQuizAttemptHistory(Guid studentId)
//     {
//         var query = new GetQuizAttemptHistoryQuery { StudentId = studentId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
// }using ELearningApi.Api.Base;
// using ELearningApi.Core.Base.ApiResponse;
// using ELearningApi.Core.MediatrHandlers.Quiz;
// using ELearningApi.Core.MediatrHandlers.Quiz.Commands.AddQuestionToQuiz;
// using ELearningApi.Core.MediatrHandlers.Quiz.Commands.CreateQuiz;
// using ELearningApi.Core.MediatrHandlers.Quiz.Commands.DeleteQuiz;
// using ELearningApi.Core.MediatrHandlers.Quiz.Commands.GenerateRandomQuiz;
// using ELearningApi.Core.MediatrHandlers.Quiz.Commands.RemoveQuestionFromQuiz;
// using ELearningApi.Core.MediatrHandlers.Quiz.Commands.UpdateQuestion;
// using ELearningApi.Core.MediatrHandlers.Quiz.Commands.UpdateQuiz;
// using ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizById;
// using ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesByCourse;
// using ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesByLecture;
// using ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesBySection;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ELearningApi.Api.Controllers;
//
// /// <summary>
// /// Controller for managing quizzes and quiz questions.
// /// </summary>
// [ApiController]
// [Route("api/[controller]")]
// [Authorize]
// public class QuizController : AppControllerBase
// {
//     /// <summary>
//     /// Creates a new quiz.
//     /// </summary>
//     /// <param name="command">The create quiz command.</param>
//     /// <returns>The created quiz.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/Quiz
//     ///     {
//     ///         "title": "Introduction to C# Quiz",
//     ///         "description": "Test your knowledge of C# basics",
//     ///         "type": 0,
//     ///         "timeLimit": 30,
//     ///         "passingScore": 70,
//     ///         "isRandomized": true,
//     ///         "showCorrectAnswers": false,
//     ///         "maxAttempts": 2,
//     ///         "availableFrom": "2023-06-01T00:00:00Z",
//     ///         "availableTo": "2023-12-31T23:59:59Z",
//     ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Quiz created successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "title": "Introduction to C# Quiz",
//     ///             "description": "Test your knowledge of C# basics",
//     ///             "type": 0,
//     ///             "timeLimit": 30,
//     ///             "passingScore": 70,
//     ///             "isRandomized": true,
//     ///             "showCorrectAnswers": false,
//     ///             "maxAttempts": 2,
//     ///             "availableFrom": "2023-06-01T00:00:00Z",
//     ///             "availableTo": "2023-12-31T23:59:59Z",
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "questions": []
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPost]
//     public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves a quiz by its ID.
//     /// </summary>
//     /// <param name="id">The ID of the quiz to retrieve.</param>
//     /// <returns>The requested quiz.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "title": "Introduction to C# Quiz",
//     ///             "description": "Test your knowledge of C# basics",
//     ///             "type": 0,
//     ///             "timeLimit": 30,
//     ///             "passingScore": 70,
//     ///             "isRandomized": true,
//     ///             "showCorrectAnswers": false,
//     ///             "maxAttempts": 2,
//     ///             "availableFrom": "2023-06-01T00:00:00Z",
//     ///             "availableTo": "2023-12-31T23:59:59Z",
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "questions": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///                     "questionText": "What is a namespace in C#?",
//     ///                     "type": 0,
//     ///                     "points": 10,
//     ///                     "difficultyLevel": 2,
//     ///                     "explanation": "A namespace is used to organize and provide a level of separation of code elements.",
//     ///                     "orderIndex": 1,
//     ///                     "answers": [
//     ///                         {
//     ///                             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
//     ///                             "answerText": "A container for classes and other namespaces",
//     ///                             "isCorrect": true,
//     ///                             "explanation": "This is the correct definition of a namespace in C#.",
//     ///                             "orderIndex": 1
//     ///                         },
//     ///                         {
//     ///                             "id": "3fa85f64-5717-4562-b3fc-2c963f66afb0",
//     ///                             "answerText": "A type of variable",
//     ///                             "isCorrect": false,
//     ///                             "explanation": "This is incorrect. A namespace is not a type of variable.",
//     ///                             "orderIndex": 2
//     ///                         }
//     ///                     ],
//     ///                     "media": []
//     ///                 }
//     ///             ]
//     ///         }
//     ///     }
//     /// </remarks>
//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetQuizById(Guid id)
//     {
//         var query = new GetQuizByIdQuery { QuizId = id };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Updates an existing quiz.
//     /// </summary>
//     /// <param name="id">The ID of the quiz to update.</param>
//     /// <param name="command">The update quiz command.</param>
//     /// <returns>The updated quiz.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     PUT /api/Quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7
//     ///     {
//     ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///         "title": "Updated C# Quiz",
//     ///         "description": "Updated test of C# knowledge",
//     ///         "type": 1,
//     ///         "timeLimit": 45,
//     ///         "passingScore": 75,
//     ///         "isRandomized": false,
//     ///         "showCorrectAnswers": true,
//     ///         "maxAttempts": 3,
//     ///         "availableFrom": "2023-07-01T00:00:00Z",
//     ///         "availableTo": "2024-06-30T23:59:59Z",
//     ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Quiz updated successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "title": "Updated C# Quiz",
//     ///             "description": "Updated test of C# knowledge",
//     ///             "type": 1,
//     ///             "timeLimit": 45,
//     ///             "passingScore": 75,
//     ///             "isRandomized": false,
//     ///             "showCorrectAnswers": true,
//     ///             "maxAttempts": 3,
//     ///             "availableFrom": "2023-07-01T00:00:00Z",
//     ///             "availableTo": "2024-06-30T23:59:59Z",
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "questions": []
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPut("{id}")]
//     public async Task<IActionResult> UpdateQuiz(Guid id, [FromBody] UpdateQuizCommand command)
//     {
//         if (id != command.Id)
//         {
//             return BadRequest("The ID in the URL does not match the ID in the request body.");
//         }
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Deletes a quiz.
//     /// </summary>
//     /// <param name="id">The ID of the quiz to delete.</param>
//     /// <returns>A success message if the quiz was deleted.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     DELETE /api/Quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Quiz deleted successfully.",
//     ///         "data": "Quiz deleted successfully."
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteQuiz(Guid id)
//     {
//         var command = new DeleteQuizCommand { Id = id };
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Adds a question to a quiz.
//     /// </summary>
//     /// <param name="quizId">The ID of the quiz to add the question to.</param>
//     /// <param name="command">The add question command.</param>
//     /// <returns>The added question.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/Quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7/question
//     ///     {
//     ///         "quizId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///         "question": {
//     ///             "questionText": "What is inheritance in C#?",
//     ///             "type": 0,
//     ///             "points": 15,
//     ///             "difficultyLevel": 3,
//     ///             "explanation": "Inheritance is a mechanism in C# that allows a class to inherit properties and methods from another class.",
//     ///             "orderIndex": 2,
//     ///             "answers": [
//     ///                 {
//     ///                     "answerText": "A mechanism for code reuse",
//     ///                     "isCorrect": true,
//     ///                     "explanation": "This is correct. Inheritance is primarily used for code reuse.",
//     ///                     "orderIndex": 1
//     ///                 },
//     ///                 {
//     ///                     "answerText": "A way to create multiple instances of a class",
//     ///                     "isCorrect": false,
//     ///                     "explanation": "This is incorrect. Creating multiple instances is not related to inheritance.",
//     ///                     "orderIndex": 2
//     ///                 }
//     ///             ]
//     ///         }
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Question added to quiz successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afb1",
//     ///             "questionText": "What is inheritance in C#?",
//     ///             "type": 0,
//     ///             "points": 15,
//     ///             "difficultyLevel": 3,
//     ///             "explanation": "Inheritance is a mechanism in C# that allows a class to inherit properties and methods from another class.",
//     ///             "orderIndex": 2,
//     ///             "answers": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afb2",
//     ///                     "answerText": "A mechanism for code reuse",
//     ///                     "isCorrect": true,
//     ///                     "explanation": "This is correct. Inheritance is primarily used for code reuse.",
//     ///                     "orderIndex": 1
//     ///                 },
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afb3",
//     ///                     "answerText": "A way to create multiple instances of a class",
//     ///                     "isCorrect": false,
//     ///                     "explanation": "This is incorrect. Creating multiple instances is not related to inheritance.",
//     ///                     "orderIndex": 2
//     ///                 }
//     ///             ],
//     ///             "media": []
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPost("{quizId}/question")]
//     public async Task<IActionResult> AddQuestionToQuiz(Guid quizId, [FromBody] AddQuestionToQuizCommand command)
//     {
//         if (quizId != command.QuizId)
//         {
//             return BadRequest("The quiz ID in the URL does not match the quiz ID in the request body.");
//         }
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Updates a question in a quiz.
//     /// </summary>
//     /// <param name="quizId">The ID of the quiz containing the question.</param>
//     /// <param name="questionId">The ID of the question to update.</param>
//     /// <param name="command">The update question command.</param>
//     /// <returns>The updated question.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     PUT /api/Quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7/question/3fa85f64-5717-4562-b3fc-2c963f66afb1
//     ///     {
//     ///         "question": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afb1",
//     ///             "questionText": "What is the primary purpose of inheritance in C#?",
//     ///             "type": 0,
//     ///             "points": 20,
//     ///             "difficultyLevel": 3,
//     ///             "explanation": "Inheritance is a fundamental concept in object-oriented programming that allows for code reuse and the creation of class hierarchies.",
//     ///             "orderIndex": 2,
//     ///             "answers": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afb2",
//     ///                     "answerText": "To enable code reuse and create class hierarchies",
//     ///                     "isCorrect": true,
//     ///                     "explanation": "This is the primary purpose of inheritance in C#.",
//     ///                     "orderIndex": 1
//     ///                 },
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afb3",
//     ///                     "answerText": "To create multiple instances of a class",
//     ///                     "isCorrect": false,
//     ///                     "explanation": "This is not the primary purpose of inheritance.",
//     ///                     "orderIndex": 2
//     ///                 }
//     ///             ]
//     ///         }
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Question updated successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afb1",
//     ///             "questionText": "What is the primary purpose of inheritance in C#?",
//     ///             "type": 0,
//     ///             "points": 20,
//     ///             "difficultyLevel": 3,
//     ///             "explanation": "Inheritance is a fundamental concept in object-oriented programming that allows for code reuse and the creation of class hierarchies.",
//     ///             "orderIndex": 2,
//     ///             "answers": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afb2",
//     ///                     "answerText": "To enable code reuse and create class hierarchies",
//     ///                     "isCorrect": true,
//     ///                     "explanation": "This is the primary purpose of inheritance in C#.",
//     ///                     "orderIndex": 1
//     ///                 },
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afb3",
//     ///                     "answerText": "To create multiple instances of a class",
//     ///                     "isCorrect": false,
//     ///                     "explanation": "This is not the primary purpose of inheritance.",
//     ///                     "orderIndex": 2
//     ///                 }
//     ///             ],
//     ///             "media": []
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPut("{quizId}/question/{questionId}")]
//     public async Task<IActionResult> UpdateQuestion(Guid quizId, Guid questionId, [FromBody] UpdateQuestionCommand command)
//     {
//         if (questionId != command.Question.Id)
//         {
//             return BadRequest("The question ID in the URL does not match the question ID in the request body.");
//         }
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Removes a question from a quiz.
//     /// </summary>
//     /// <param name="quizId">The ID of the quiz containing the question.</param>
//     /// <param name="questionId">The ID of the question to remove.</param>
//     /// <returns>A success message if the question was removed.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     DELETE /api/Quiz/3fa85f64-5717-4562-b3fc-2c963f66afa7/question/3fa85f64-5717-4562-b3fc-2c963f66afb1
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Question removed from quiz successfully.",
//     ///         "data": "Question removed from quiz successfully."
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpDelete("{quizId}/question/{questionId}")]
//     public async Task<IActionResult> RemoveQuestionFromQuiz(Guid quizId, Guid questionId)
//     {
//         var command = new RemoveQuestionFromQuizCommand { QuizId = quizId, QuestionId = questionId };
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves all quizzes for a specific course.
//     /// </summary>
//     /// <param name="courseId">The ID of the course.</param>
//     /// <returns>A list of quizzes for the specified course.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Quiz/course/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "title": "C# Basics Quiz",
//     ///                 "description": "Test your knowledge of C# fundamentals",
//     ///                 "type": 0,
//     ///                 "timeLimit": 30,
//     ///                 "passingScore": 70,
//     ///                 "isRandomized": true,
//     ///                 "showCorrectAnswers": false,
//     ///                 "maxAttempts": 2,
//     ///                 "availableFrom": "2023-06-01T00:00:00Z",
//     ///                 "availableTo": "2023-12-31T23:59:59Z",
//     ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "questions": []
//     ///             },
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///                 "title": "Advanced C# Concepts",
//     ///                 "description": "Challenge yourself with advanced C# topics",
//     ///                 "type": 1,
//     ///                 "timeLimit": 45,
//     ///                 "passingScore": 80,
//     ///                 "isRandomized": false,
//     ///                 "showCorrectAnswers": true,
//     ///                 "maxAttempts": 3,
//     ///                 "availableFrom": "2023-07-01T00:00:00Z",
//     ///                 "availableTo": "2023-12-31T23:59:59Z",
//     ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "questions": []
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("course/{courseId}")]
//     public async Task<IActionResult> GetQuizzesByCourse(Guid courseId)
//     {
//         var query = new GetQuizzesByCourseQuery { CourseId = courseId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves all quizzes for a specific section.
//     /// </summary>
//     /// <param name="sectionId">The ID of the section.</param>
//     /// <returns>A list of quizzes for the specified section.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Quiz/section/3fa85f64-5717-4562-b3fc-2c963f66afa9
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afaa",
//     ///                 "title": "Section 1 Quiz",
//     ///                 "description": "Test your knowledge of Section 1 content",
//     ///                 "type": 0,
//     ///                 "timeLimit": 20,
//     ///                 "passingScore": 75,
//     ///                 "isRandomized": true,
//     ///                 "showCorrectAnswers": false,
//     ///                 "maxAttempts": 2,
//     ///                 "availableFrom": "2023-06-01T00:00:00Z",
//     ///                 "availableTo": "2023-12-31T23:59:59Z",
//     ///                 "sectionId": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
//     ///                 "questions": []
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("section/{sectionId}")]
//     public async Task<IActionResult> GetQuizzesBySection(Guid sectionId)
//     {
//         var query = new GetQuizzesBySectionQuery { SectionId = sectionId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves all quizzes for a specific lecture.
//     /// </summary>
//     /// <param name="lectureId">The ID of the lecture.</param>
//     /// <returns>A list of quizzes for the specified lecture.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Quiz/lecture/3fa85f64-5717-4562-b3fc-2c963f66afab
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afac",
//     ///                 "title": "Lecture Quiz",
//     ///                 "description": "Quick quiz on lecture content",
//     ///                 "type": 0,
//     ///                 "timeLimit": 10,
//     ///                 "passingScore": 80,
//     ///                 "isRandomized": false,
//     ///                 "showCorrectAnswers": true,
//     ///                 "maxAttempts": 1,
//     ///                 "availableFrom": "2023-06-01T00:00:00Z",
//     ///                 "availableTo": "2023-12-31T23:59:59Z",
//     ///                 "lectureId": "3fa85f64-5717-4562-b3fc-2c963f66afab",
//     ///                 "questions": []
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("lecture/{lectureId}")]
//     public async Task<IActionResult> GetQuizzesByLecture(Guid lectureId)
//     {
//         var query = new GetQuizzesByLectureQuery { LectureId = lectureId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Generates a random quiz for a specific course.
//     /// </summary>
//     /// <param name="courseId">The ID of the course.</param>
//     /// <param name="questionCount">The number of questions to include in the random quiz.</param>
//     /// <returns>The generated random quiz.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/Quiz/random?courseId=3fa85f64-5717-4562-b3fc-2c963f66afa6&amp;questionCount=5
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Random quiz generated successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afad",
//     ///             "title": "Random Quiz",
//     ///             "description": "Randomly generated quiz",
//     ///             "type": 0,
//     ///             "timeLimit": null,
//     ///             "passingScore": 0,
//     ///             "isRandomized": true,
//     ///             "showCorrectAnswers": false,
//     ///             "maxAttempts": 1,
//     ///             "availableFrom": "2023-06-07T00:00:00Z",
//     ///             "availableTo": null,
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "questions": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afae",
//     ///                     "questionText": "What is a namespace in C#?",
//     ///                     "type": 0,
//     ///                     "points": 10,
//     ///                     "difficultyLevel": 2,
//     ///                     "explanation": "A namespace is used to organize and provide a level of separation of code elements.",
//     ///                     "orderIndex": 1,
//     ///                     "answers": [
//     ///                         {
//     ///                             "id": "3fa85f64-5717-4562-b3fc-2c963f66afaf",
//     ///                             "answerText": "A container for classes and other namespaces",
//     ///                             "isCorrect": true,
//     ///                             "explanation": "This is the correct definition of a namespace in C#.",
//     ///                             "orderIndex": 1
//     ///                         },
//     ///                         {
//     ///                             "id": "3fa85f64-5717-4562-b3fc-2c963f66afb0",
//     ///                             "answerText": "A type of variable",
//     ///                             "isCorrect": false,
//     ///                             "explanation": "This is incorrect. A namespace is not a type of variable.",
//     ///                             "orderIndex": 2
//     ///                         }
//     ///                     ],
//     ///                     "media": []
//     ///                 },
//     ///                 // ... more questions ...
//     ///             ]
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPost("random")]
//     public async Task<IActionResult> GenerateRandomQuiz([FromQuery] Guid courseId, [FromQuery] int questionCount)
//     {
//         var command = new GenerateRandomQuizCommand { CourseId = courseId, QuestionCount = questionCount };
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
// }using ELearningApi.Api.Base;
// using ELearningApi.Core.MediatrHandlers.Review.Commands.CreateReview;
// using ELearningApi.Core.MediatrHandlers.Review.Commands.DeleteReview;
// using ELearningApi.Core.MediatrHandlers.Review.Commands.UpdateReview;
// using ELearningApi.Core.MediatrHandlers.Review.Queries.GetCourseAverageRating;
// using ELearningApi.Core.MediatrHandlers.Review.Queries.GetReviewById;
// using ELearningApi.Core.MediatrHandlers.Review.Queries.GetReviewsForCourse;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ELearningApi.Api.Controllers;
//
// /// <summary>
// /// Controller for managing reviews.
// /// </summary>
// [Authorize]
// [ApiController]
// [Route("api/[controller]")]
// public class ReviewController : AppControllerBase
// {
//     /// <summary>
//     /// Creates a new review for a course.
//     /// </summary>
//     /// <param name="command">The create review command.</param>
//     /// <returns>The created review.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/Review
//     ///     {
//     ///         "rating": 4,
//     ///         "comment": "Great course, very informative!",
//     ///         "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 201,
//     ///         "succeeded": true,
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///             "rating": 4,
//     ///             "comment": "Great course, very informative!",
//     ///             "createdAt": "2023-06-07T10:00:00Z",
//     ///             "updatedAt": "2023-06-07T10:00:00Z",
//     ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Student")]
//     [HttpPost]
//     public async Task<IActionResult> CreateReview([FromBody] CreateReviewCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves a specific review by its ID.
//     /// </summary>
//     /// <param name="id">The ID of the review to retrieve.</param>
//     /// <returns>The requested review.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Review/3fa85f64-5717-4562-b3fc-2c963f66afa8
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///             "rating": 4,
//     ///             "comment": "Great course, very informative!",
//     ///             "createdAt": "2023-06-07T10:00:00Z",
//     ///             "updatedAt": "2023-06-07T10:00:00Z",
//     ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
//     ///         }
//     ///     }
//     /// </remarks>
//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetReviewById(Guid id)
//     {
//         var query = new GetReviewByIdQuery { Id = id };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Updates an existing review.
//     /// </summary>
//     /// <param name="id">The ID of the review to update.</param>
//     /// <param name="command">The update review command.</param>
//     /// <returns>The updated review.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     PUT /api/Review/3fa85f64-5717-4562-b3fc-2c963f66afa8
//     ///     {
//     ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///         "rating": 5,
//     ///         "comment": "Excellent course, highly recommended!"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///             "rating": 5,
//     ///             "comment": "Excellent course, highly recommended!",
//     ///             "createdAt": "2023-06-07T10:00:00Z",
//     ///             "updatedAt": "2023-06-07T11:00:00Z",
//     ///             "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Student")]
//     [HttpPut("{id}")]
//     public async Task<IActionResult> UpdateReview(Guid id, [FromBody] UpdateReviewCommand command)
//     {
//         if (id != command.Id)
//         {
//             return BadRequest("The ID in the URL does not match the ID in the request body.");
//         }
//
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Deletes a specific review.
//     /// </summary>
//     /// <param name="id">The ID of the review to delete.</param>
//     /// <returns>A success message if the review was deleted.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     DELETE /api/Review/3fa85f64-5717-4562-b3fc-2c963f66afa8
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Review deleted successfully.",
//     ///         "data": "Review deleted successfully."
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Student")]
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteReview(Guid id)
//     {
//         var command = new DeleteReviewCommand { Id = id };
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves reviews for a specific course.
//     /// </summary>
//     /// <param name="courseId">The ID of the course.</param>
//     /// <param name="page">The page number (default is 1).</param>
//     /// <param name="pageSize">The number of items per page (default is 10).</param>
//     /// <returns>A paged list of reviews for the specified course.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Review/course/3fa85f64-5717-4562-b3fc-2c963f66afa7?page=1&amp;pageSize=10
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": {
//     ///             "items": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///                     "rating": 5,
//     ///                     "comment": "Excellent course, highly recommended!",
//     ///                     "createdAt": "2023-06-07T10:00:00Z",
//     ///                     "updatedAt": "2023-06-07T11:00:00Z",
//     ///                     "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                     "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
//     ///                 },
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
//     ///                     "rating": 4,
//     ///                     "comment": "Very informative course.",
//     ///                     "createdAt": "2023-06-06T15:00:00Z",
//     ///                     "updatedAt": "2023-06-06T15:00:00Z",
//     ///                     "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afaa",
//     ///                     "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa7"
//     ///                 }
//     ///             ],
//     ///             "pageNumber": 1,
//     ///             "pageSize": 10,
//     ///             "totalCount": 2,
//     ///             "totalPages": 1,
//     ///             "hasPreviousPage": false,
//     ///             "hasNextPage": false
//     ///         }
//     ///     }
//     /// </remarks>
//     [HttpGet("course/{courseId}")]
//     public async Task<IActionResult> GetReviewsForCourse(Guid courseId, [FromQuery] int page = 1,
//         [FromQuery] int pageSize = 10)
//     {
//         var query = new GetReviewsForCourseQuery { CourseId = courseId, Page = page, PageSize = pageSize };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Calculates the average rating for a specific course.
//     /// </summary>
//     /// <param name="courseId">The ID of the course.</param>
//     /// <returns>The average rating for the specified course.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Review/average-rating/3fa85f64-5717-4562-b3fc-2c963f66afa7
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": "4.5"
//     ///     }
//     /// </remarks>
//     [HttpGet("average-rating/{courseId}")]
//     public async Task<IActionResult> GetCourseAverageRating(Guid courseId)
//     {
//         var query = new GetCourseAverageRatingQuery { CourseId = courseId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
// }using ELearningApi.Api.Base;
// using ELearningApi.Core.MediatrHandlers.Search.GlobalSearch;
// using ELearningApi.Core.MediatrHandlers.Search.SearchCourses;
// using ELearningApi.Core.MediatrHandlers.Search.SearchInstructors;
// using ELearningApi.Core.MediatrHandlers.Search.SearchLectures;
// using ELearningApi.Data.Enums;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ELearningApi.Api.Controllers;
//
// /// <summary>
// /// Controller for handling search-related operations.
// /// </summary>
// [ApiController]
// [Route("api/[controller]")]
// [Authorize]
// public class SearchController : AppControllerBase
// {
//     /// <summary>
//     /// Performs a global search across courses, instructors, and lectures.
//     /// </summary>
//     /// <param name="searchTerm">The term to search for.</param>
//     /// <returns>A collection of courses, instructors, and lectures that match the search term.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Search/global?searchTerm=programming
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Global search completed successfully.",
//     ///         "data": {
//     ///             "courses": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                     "title": "Introduction to Programming",
//     ///                     "shortDescription": "Learn the basics of programming",
//     ///                     "price": 49.99,
//     ///                     "instructorName": "John Doe",
//     ///                     "categoryName": "Computer Science",
//     ///                     "level": 0,
//     ///                     "estimatedDuration": "10:00:00"
//     ///                 }
//     ///             ],
//     ///             "instructors": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                     "name": "Jane Smith",
//     ///                     "email": "jane.smith@example.com",
//     ///                     "expertise": "Programming, Web Development",
//     ///                     "biography": "Experienced programmer with 10 years in the industry"
//     ///                 }
//     ///             ],
//     ///             "lectures": [
//     ///                 {
//     ///                     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///                     "title": "Variables and Data Types",
//     ///                     "description": "Understanding basic programming concepts",
//     ///                     "duration": "00:45:00",
//     ///                     "courseName": "Introduction to Programming",
//     ///                     "sectionName": "Basics of Programming"
//     ///                 }
//     ///             ]
//     ///         }
//     ///     }
//     /// </remarks>
//     [HttpGet("global")]
//     public async Task<IActionResult> GlobalSearch([FromQuery] string searchTerm)
//     {
//         var query = new GlobalSearchQuery { SearchTerm = searchTerm };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Searches for courses based on various criteria.
//     /// </summary>
//     /// <param name="searchTerm">The term to search for in course titles and descriptions.</param>
//     /// <param name="level">The course level to filter by (optional).</param>
//     /// <param name="categoryId">The category ID to filter by (optional).</param>
//     /// <param name="minPrice">The minimum price to filter by (optional).</param>
//     /// <param name="maxPrice">The maximum price to filter by (optional).</param>
//     /// <returns>A collection of courses that match the search criteria.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Search/courses?searchTerm=programming&amp;level=1&amp;categoryId=3fa85f64-5717-4562-b3fc-2c963f66afa9&amp;minPrice=20&amp;maxPrice=100
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Courses retrieved successfully.",
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     ///                 "title": "Advanced Programming Techniques",
//     ///                 "shortDescription": "Take your programming skills to the next level",
//     ///                 "price": 79.99,
//     ///                 "instructorName": "John Doe",
//     ///                 "categoryName": "Computer Science",
//     ///                 "level": 1,
//     ///                 "estimatedDuration": "15:00:00"
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("courses")]
//     public async Task<IActionResult> SearchCourses(
//         [FromQuery] string searchTerm,
//         [FromQuery] CourseLevel? level = null,
//         [FromQuery] Guid? categoryId = null,
//         [FromQuery] decimal? minPrice = null,
//         [FromQuery] decimal? maxPrice = null)
//     {
//         var query = new SearchCoursesQuery
//         {
//             SearchTerm = searchTerm,
//             Level = level,
//             CategoryId = categoryId,
//             MinPrice = minPrice,
//             MaxPrice = maxPrice
//         };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Searches for instructors based on a search term and expertise.
//     /// </summary>
//     /// <param name="searchTerm">The term to search for in instructor names and biographies.</param>
//     /// <param name="expertise">The expertise to filter by (optional).</param>
//     /// <returns>A collection of instructors that match the search criteria.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Search/instructors?searchTerm=programming&amp;expertise=web development
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Instructors retrieved successfully.",
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "name": "Jane Smith",
//     ///                 "email": "jane.smith@example.com",
//     ///                 "expertise": "Programming, Web Development",
//     ///                 "biography": "Experienced programmer with 10 years in the industry"
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("instructors")]
//     public async Task<IActionResult> SearchInstructors([FromQuery] string searchTerm,
//         [FromQuery] string? expertise = null)
//     {
//         var query = new SearchInstructorsQuery { SearchTerm = searchTerm, Expertise = expertise };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Searches for lectures based on a search term and optionally filtered by course.
//     /// </summary>
//     /// <param name="searchTerm">The term to search for in lecture titles, descriptions, and content.</param>
//     /// <param name="courseId">The course ID to filter by (optional).</param>
//     /// <returns>A collection of lectures that match the search criteria.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Search/lectures?searchTerm=variables&amp;courseId=3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Lectures retrieved successfully.",
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///                 "title": "Variables and Data Types",
//     ///                 "description": "Understanding basic programming concepts",
//     ///                 "duration": "00:45:00",
//     ///                 "courseName": "Introduction to Programming",
//     ///                 "sectionName": "Basics of Programming"
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("lectures")]
//     public async Task<IActionResult> SearchLectures([FromQuery] string searchTerm, [FromQuery] Guid? courseId = null)
//     {
//         var query = new SearchLecturesQuery { SearchTerm = searchTerm, CourseId = courseId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
// }using ELearningApi.Api.Base;
// using ELearningApi.Core.MediatrHandlers.Section.Commands.CreateSection;
// using ELearningApi.Core.MediatrHandlers.Section.Commands.DeleteSection;
// using ELearningApi.Core.MediatrHandlers.Section.Commands.UpdateSection;
// using ELearningApi.Core.MediatrHandlers.Section.Queries.GetSectionById;
// using ELearningApi.Core.MediatrHandlers.Section.Queries.GetSectionsForCourse;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ELearningApi.Api.Controllers;
//
// /// <summary>
// /// Controller for managing sections of a course.
// /// </summary>
// [Authorize]
// [ApiController]
// [Route("api/[controller]")]
// public class SectionController : AppControllerBase
// {
//     /// <summary>
//     /// Creates a new section for a course.
//     /// </summary>
//     /// <param name="command">The create section command.</param>
//     /// <returns>The created section.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     POST /api/Section
//     ///     {
//     ///         "title": "Introduction to C#",
//     ///         "description": "Learn the basics of C# programming",
//     ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Section created successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "title": "Introduction to C#",
//     ///             "description": "Learn the basics of C# programming",
//     ///             "orderIndex": 1,
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPost]
//     public async Task<IActionResult> CreateSection([FromBody] CreateSectionCommand command)
//     {
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves a specific section by its ID.
//     /// </summary>
//     /// <param name="id">The ID of the section to retrieve.</param>
//     /// <returns>The requested section.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Section/3fa85f64-5717-4562-b3fc-2c963f66afa7
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "title": "Introduction to C#",
//     ///             "description": "Learn the basics of C# programming",
//     ///             "orderIndex": 1,
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ///         }
//     ///     }
//     /// </remarks>
//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetSectionById(Guid id)
//     {
//         var query = new GetSectionByIdQuery { Id = id };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Updates an existing section.
//     /// </summary>
//     /// <param name="id">The ID of the section to update.</param>
//     /// <param name="command">The update section command.</param>
//     /// <returns>The updated section.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     PUT /api/Section/3fa85f64-5717-4562-b3fc-2c963f66afa7
//     ///     {
//     ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///         "title": "Advanced C# Concepts",
//     ///         "description": "Dive deeper into C# programming",
//     ///         "orderIndex": 2,
//     ///         "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ///     }
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Section updated successfully.",
//     ///         "data": {
//     ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///             "title": "Advanced C# Concepts",
//     ///             "description": "Dive deeper into C# programming",
//     ///             "orderIndex": 2,
//     ///             "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ///         }
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpPut("{id}")]
//     public async Task<IActionResult> UpdateSection(Guid id, [FromBody] UpdateSectionCommand command)
//     {
//         if (id != command.Id)
//         {
//             return BadRequest("The ID in the URL does not match the ID in the request body.");
//         }
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Deletes a specific section.
//     /// </summary>
//     /// <param name="id">The ID of the section to delete.</param>
//     /// <returns>A success message if the section was deleted.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     DELETE /api/Section/3fa85f64-5717-4562-b3fc-2c963f66afa7
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "message": "Section deleted successfully.",
//     ///         "data": "Section deleted successfully."
//     ///     }
//     /// </remarks>
//     [Authorize(Roles = "Admin,Instructor")]
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteSection(Guid id)
//     {
//         var command = new DeleteSectionCommand { Id = id };
//         var result = await Mediator.Send(command);
//         return CreateResponse(result);
//     }
//
//     /// <summary>
//     /// Retrieves all sections for a specific course.
//     /// </summary>
//     /// <param name="courseId">The ID of the course.</param>
//     /// <returns>A list of sections for the specified course.</returns>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /api/Section/course/3fa85f64-5717-4562-b3fc-2c963f66afa6
//     ///
//     /// Sample response:
//     ///
//     ///     {
//     ///         "statusCode": 200,
//     ///         "succeeded": true,
//     ///         "data": [
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
//     ///                 "title": "Introduction to C#",
//     ///                 "description": "Learn the basics of C# programming",
//     ///                 "orderIndex": 1,
//     ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ///             },
//     ///             {
//     ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
//     ///                 "title": "Advanced C# Concepts",
//     ///                 "description": "Dive deeper into C# programming",
//     ///                 "orderIndex": 2,
//     ///                 "courseId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ///             }
//     ///         ]
//     ///     }
//     /// </remarks>
//     [HttpGet("course/{courseId}")]
//     public async Task<IActionResult> GetSectionsForCourse(Guid courseId)
//     {
//         var query = new GetSectionsForCourseQuery { CourseId = courseId };
//         var result = await Mediator.Send(query);
//         return CreateResponse(result);
//     }
// }using ELearningApi.Api.Base;
// using Microsoft.AspNetCore.Mvc;
// using ELearningApi.Core.MediatrHandlers.Student.Commands.UpdateStudent;
// using ELearningApi.Core.MediatrHandlers.Student.Queries.GetAllStudents;
// using ELearningApi.Core.MediatrHandlers.Student.Queries.GetStudentById;
// using Microsoft.AspNetCore.Authorization;
//
// namespace ELearningApi.Api.Controllers
// {
//     /// <summary>
//     /// Controller for managing students.
//     /// </summary>
//     [Route("api/[controller]")]
//     [ApiController]
//     [Authorize]
//     public class StudentsController : AppControllerBase
//     {
//         /// <summary>
//         /// Gets a student by id.
//         /// </summary>
//         /// <param name="id">The id of the student.</param>
//         /// <returns>The student.</returns>
//         /// <remarks>
//         /// Sample request:
//         /// 
//         ///     GET /api/students/3fa85f64-5717-4562-b3fc-2c963f66afa6
//         /// 
//         /// Sample response:
//         /// 
//         ///     {
//         ///         "data": {
//         ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         ///             "firstName": "John",
//         ///             "lastName": "Doe",
//         ///             "email": "john.doe@example.com"
//         ///         },
//         ///         "message": "Student retrieved successfully.",
//         ///         "statusCode": 200,
//         ///         "error": null
//         ///     }
//         /// 
//         /// </remarks>
//         /// <response code="200">Returns the requested student</response>
//         /// <response code="404">If the student is not found</response>
//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetStudentById(Guid id)
//         {
//             var result = await Mediator.Send(new GetStudentByIdQuery { Id = id });
//             return CreateResponse(result);
//         }
//
//         /// <summary>
//         /// Gets all students.
//         /// </summary>
//         /// <returns>List of all students.</returns>
//         /// <remarks>
//         /// Sample request:
//         /// 
//         ///     GET /api/students
//         /// 
//         /// Sample response:
//         /// 
//         ///     {
//         ///         "data": [
//         ///             {
//         ///                 "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         ///                 "firstName": "John",
//         ///                 "lastName": "Doe",
//         ///                 "email": "john.doe@example.com"
//         ///             },
//         ///             {
//         ///                 "id": "8a1b9c3d-4e5f-6g7h-8i9j-0k1l2m3n4o5p",
//         ///                 "firstName": "Jane",
//         ///                 "lastName": "Smith",
//         ///                 "email": "jane.smith@example.com"
//         ///             }
//         ///         ],
//         ///         "message": "Students retrieved successfully.",
//         ///         "statusCode": 200,
//         ///         "error": null
//         ///     }
//         /// 
//         /// </remarks>
//         /// <response code="200">Returns the list of students</response>
//         [Authorize(Roles = "Admin,Instructor")]
//         [HttpGet]
//         public async Task<IActionResult> GetAllStudents()
//         {
//             var result = await Mediator.Send(new GetAllStudentsQuery());
//             return CreateResponse(result);
//         }
//
//         /// <summary>
//         /// Updates an existing student.
//         /// </summary>
//         /// <param name="id">The id of the student to update.</param>
//         /// <param name="command">The update student command.</param>
//         /// <returns>The updated student.</returns>
//         /// <remarks>
//         /// Sample request:
//         /// 
//         ///     PUT /api/students/3fa85f64-5717-4562-b3fc-2c963f66afa6
//         ///     {
//         ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         ///         "firstName": "John",
//         ///         "lastName": "Smith",
//         ///         "email": "john.smith@example.com"
//         ///     }
//         /// 
//         /// Sample response:
//         /// 
//         ///     {
//         ///         "data": {
//         ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         ///             "firstName": "John",
//         ///             "lastName": "Smith",
//         ///             "email": "john.smith@example.com"
//         ///         },
//         ///         "message": "Student updated successfully.",
//         ///         "statusCode": 200,
//         ///         "error": null
//         ///     }
//         /// 
//         /// </remarks>
//         /// <response code="200">Returns the updated student</response>
//         /// <response code="400">If the item is null or invalid</response>
//         /// <response code="404">If the student is not found</response>
//         [Authorize(Roles = "Admin,Student")]
//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] UpdateStudentCommand command)
//         {
//             if (id != command.Id)
//                 return BadRequest("The ID in the URL does not match the ID in the request body.");
//
//             var result = await Mediator.Send(command);
//             return CreateResponse(result);
//         }
//     }
// }