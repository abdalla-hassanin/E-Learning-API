using ELearningApi.Api.Base;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Core.MediatrHandlers.Auth;
using ELearningApi.Core.MediatrHandlers.Auth.ChangePassword;
using ELearningApi.Core.MediatrHandlers.Auth.ConfirmEmail;
using ELearningApi.Core.MediatrHandlers.Auth.ForgotPassword;
using ELearningApi.Core.MediatrHandlers.Auth.Login;
using ELearningApi.Core.MediatrHandlers.Auth.RefreshToken;
using ELearningApi.Core.MediatrHandlers.Auth.RegisterInstructor;
using ELearningApi.Core.MediatrHandlers.Auth.RegisterStudent;
using ELearningApi.Core.MediatrHandlers.Auth.ResendEmailConfirmation;
using ELearningApi.Core.MediatrHandlers.Auth.ResetPassword;
using ELearningApi.Core.MediatrHandlers.Auth.RevokeToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Api.Controllers;

/// <summary>
/// Controller for handling authentication and authorization operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : AppControllerBase
{
    /// <summary>
    /// Register a new student.
    /// </summary>
    /// <param name="command">The registration details for the student.</param>
    /// <returns>A response containing the authentication result.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/Auth/register-student
    ///     {
    ///         "email": "student@example.com",
    ///         "password": "StrongPass123!",
    ///         "firstName": "John",
    ///         "lastName": "Doe"
    ///     }
    /// 
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Student registered successfully. Please check your email to confirm your account.",
    ///         "data": {
    ///             "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    ///             "refreshToken": "6ce32ced-c327-4e5c-9d57-7582f7deee24",
    ///             "tokenExpiration": "2023-06-15T14:30:00Z"
    ///         }
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Returns the authentication result if registration is successful.</response>
    /// <response code="400">If the registration fails due to invalid input.</response>
    [HttpPost("register-student")]
    public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Register a new instructor.
    /// </summary>
    /// <param name="command">The registration details for the instructor.</param>
    /// <returns>A response containing the authentication result.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/Auth/register-instructor
    ///     {
    ///         "email": "instructor@example.com",
    ///         "password": "StrongPass123!",
    ///         "firstName": "Jane",
    ///         "lastName": "Smith",
    ///         "expertise": "Computer Science",
    ///         "biography": "Experienced instructor with 10 years in the field."
    ///     }
    /// 
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Instructor registered successfully. Please check your email to confirm your account.",
    ///         "data": {
    ///             "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    ///             "refreshToken": "7de43def-d328-5f6d-0e68-8693g8eff35",
    ///             "tokenExpiration": "2023-06-15T14:30:00Z"
    ///         }
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Returns the authentication result if registration is successful.</response>
    /// <response code="400">If the registration fails due to invalid input.</response>
    [HttpPost("register-instructor")]
    public async Task<IActionResult> RegisterInstructor([FromBody] RegisterInstructorCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Authenticate a user and return a JWT token.
    /// </summary>
    /// <param name="command">The login credentials.</param>
    /// <returns>A response containing the authentication result with JWT token.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/Auth/login
    ///     {
    ///         "email": "user@example.com",
    ///         "password": "StrongPass123!"
    ///     }
    /// 
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Login successful",
    ///         "data": {
    ///             "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    ///             "refreshToken": "8ef54fgh-e439-6g7h-1f79-9704h9fgg46",
    ///             "tokenExpiration": "2023-06-15T16:30:00Z"
    ///         }
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Returns the authentication result with JWT token if login is successful.</response>
    /// <response code="401">If the login fails due to invalid credentials.</response>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Refresh the JWT token using a refresh token.
    /// </summary>
    /// <param name="command">The refresh token command containing the current access token and refresh token.</param>
    /// <returns>A response containing the new JWT token and refresh token.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/Auth/refresh-token
    ///     {
    ///         "accessToken": "eyJhbGciOiJIUzI1NiIsInR5...",
    ///         "refreshToken": "6ce32ced-c327-4e5c-9d57-..."
    ///     }
    /// 
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Token refreshed successfully",
    ///         "data": {
    ///             "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    ///             "refreshToken": "9fg65hij-f540-7i8j-2g80-0815i0ghh57",
    ///             "tokenExpiration": "2023-06-15T18:30:00Z"
    ///         }
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Returns the new JWT token and refresh token if refresh is successful.</response>
    /// <response code="401">If the refresh token is invalid or expired.</response>
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Revoke the refresh token for a user.
    /// </summary>
    /// <param name="command">The command containing the username of the user whose token should be revoked.</param>
    /// <returns>A response indicating the success of the operation.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/Auth/revoke-token
    ///     {
    ///         "username": "user@example.com"
    ///     }
    /// 
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Token revoked successfully",
    ///         "data": null
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Returns a success message if the token was revoked.</response>
    /// <response code="400">If the username is invalid or not found.</response>
    [Authorize]
    [HttpPost("revoke-token")]
    public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Initiate the forgot password process for a user.
    /// </summary>
    /// <param name="command">The command containing the email of the user who forgot their password.</param>
    /// <returns>A response indicating that a password reset email has been sent if the email exists.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/Auth/forgot-password
    ///     {
    ///         "email": "user@example.com"
    ///     }
    /// 
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "If that email address is in our system, we have sent a password reset link to it.",
    ///         "data": null
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Returns a success message indicating that a password reset email has been sent (if the email exists).</response>
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Reset a user's password using a reset token.
    /// </summary>
    /// <param name="command">The command containing the email, reset token, and new password.</param>
    /// <returns>A response indicating the success of the password reset operation.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/Auth/reset-password
    ///     {
    ///         "email": "user@example.com",
    ///         "token": "CfDJ8NrQMN9ZrPJkwh...",
    ///         "newPassword": "NewStrongPass123!"
    ///     }
    /// 
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Password has been reset successfully.",
    ///         "data": null
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Returns a success message if the password was reset successfully.</response>
    /// <response code="400">If the reset token is invalid or expired.</response>
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Change the password for an authenticated user.
    /// </summary>
    /// <param name="command">The command containing the username, current password, and new password.</param>
    /// <returns>A response indicating the success of the password change operation.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/Auth/change-password
    ///     {
    ///         "username": "user@example.com",
    ///         "currentPassword": "OldStrongPass123!",
    ///         "newPassword": "NewStrongPass123!"
    ///     }
    /// 
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Password changed successfully.",
    ///         "data": null
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Returns a success message if the password was changed successfully.</response>
    /// <response code="400">If the current password is incorrect or the new password is invalid.</response>
    [Authorize]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }

    /// <summary>
    /// Confirm a user's email address using a confirmation token.
    /// </summary>
    /// <param name="userId">The ID of the user whose email is being confirmed.</param>
    /// <param name="token">The email confirmation token.</param>
    /// <returns>A response indicating the success of the email confirmation.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET /api/Auth/confirm-email?userId=123e4567-e89b-12d3-a456-426614174000&amp;token=CfDJ8NrQMN9ZrPJkwh...
    /// 
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Thank you for confirming your email. Your account is now fully activated.",
    ///         "data": null
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Returns a success message if the email was confirmed successfully.</response>
    /// <response code="400">If the confirmation token is invalid, expired, or has already been used.</response>
    /// <response code="404">If the user ID is not found in the system.</response>
    /// <response code="500">If there's an unexpected error during the confirmation process.</response>
    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string token)
    {
        var result = await Mediator.Send(new ConfirmEmailCommand { UserId = userId, Token = token });
        return CreateResponse(result);
    }

    /// <summary>
    /// Resend the email confirmation link to a user.
    /// </summary>
    /// <param name="command">The command containing the email address to resend the confirmation to.</param>
    /// <returns>A response indicating that the confirmation email has been resent.</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/Auth/resend-email-confirmation
    ///     {
    ///         "email": "user@example.com"
    ///     }
    /// 
    /// Sample response:
    /// 
    ///     {
    ///         "statusCode": 200,
    ///         "succeeded": true,
    ///         "message": "Verification email sent. Please check your email.",
    ///         "data": null
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Returns a success message indicating that the confirmation email has been resent.</response>
    /// <response code="400">If the email is already confirmed or not found.</response>
    [HttpPost("resend-email-confirmation")]
    public async Task<IActionResult> ResendEmailConfirmation([FromBody] ResendEmailConfirmationCommand command)
    {
        var result = await Mediator.Send(command);
        return CreateResponse(result);
    }
}