using ELearningApi.Data.Entities;
using ELearningApi.Service.Base;

namespace ELearningApi.Service.IService;

public interface IAuthService
{
    Task<AuthResult> RegisterUserAsync(ApplicationUser user, string password, string role);
    Task<AuthResult> LoginAsync(string username, string password);
    Task<AuthResult> RefreshTokenAsync(string accessToken, string refreshToken);
    Task RevokeTokenAsync(string username);
    Task<AuthResult> ForgotPasswordAsync(string email);
    Task<AuthResult> ResetPasswordAsync(string email, string token, string newPassword);
    Task<AuthResult> ChangePasswordAsync(string username, string currentPassword, string newPassword);
    Task<AuthResult> ConfirmEmailAsync(string userId, string token);
    Task<AuthResult> ResendEmailConfirmationAsync(string email);
}