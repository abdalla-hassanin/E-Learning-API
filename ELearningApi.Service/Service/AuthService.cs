using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using ELearningApi.Data.Entities;
using ELearningApi.Service.Base;
using ELearningApi.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;

namespace ELearningApi.Service.Service;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userService;
    private readonly ITokenService _tokenService;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<ApplicationUser> userService, ITokenService tokenService, IEmailService emailService, IConfiguration configuration)
    {
        _userService = userService;
        _tokenService = tokenService;
        _emailService = emailService;
        _configuration = configuration;
    }

    public async Task<AuthResult> RegisterUserAsync(ApplicationUser user, string password, string role)
    
    {
        
        var result = await _userService.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await _userService.AddToRoleAsync(user, role);
            // await _userService.AddClaimAsync(user, new Claim("Permission", role == "Student" ? "ViewGrades" : "ManageGrades"));

            var token = await _userService.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var callbackUrl = $"{_configuration["AppUrl"]}/api/Auth/confirm-email?userId={user.Id}&token={encodedToken}";

            await _emailService.SendEmailAsync(user.Email!, "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            return new AuthResult { Succeeded = true, Message = $"{role} registered successfully. Please check your email to confirm your account." };
        }
        return new AuthResult 
        { 
            Succeeded = false, 
            Errors = result.Errors.Select(e => e.Description).ToList(),
            Message = "Registration failed. See errors for details."
        };
        
    }

    public async Task<AuthResult> LoginAsync(string username, string password)
    {
        var user = await _userService.FindByNameAsync(username);
        if (user != null && await _userService.CheckPasswordAsync(user, password))
        {
            var userRoles = await _userService.GetRolesAsync(user);
            // var userClaims = await _userService.GetClaimsAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
            // authClaims.AddRange(userClaims);

            var token = _tokenService.GenerateAccessToken(authClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            var tokenExpiration = DateTime.UtcNow.AddMinutes(_tokenService.GetAccessTokenExpirationMinutes());


            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            await _userService.UpdateAsync(user);

            return new AuthResult
            {
                Succeeded = true,
                Token = token,
                RefreshToken = refreshToken,
                TokenExpiration = tokenExpiration,
                Message = "Login successful"
            };
        }
        return new AuthResult { Succeeded = false, Message = "Invalid username or password" };
    }

    public async Task<AuthResult> RefreshTokenAsync(string accessToken, string refreshToken)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
        if (principal == null)
        {
            return new AuthResult { Succeeded = false, Message = "Invalid access token or refresh token" };
        }

        string username = principal.Identity.Name;
        var user = await _userService.FindByNameAsync(username);

        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return new AuthResult { Succeeded = false, Message = "Invalid access token or refresh token" };
        }

        var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
        var newRefreshToken = _tokenService.GenerateRefreshToken();
        var tokenExpiration = DateTime.UtcNow.AddMinutes(_tokenService.GetAccessTokenExpirationMinutes());
        
        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

        await _userService.UpdateAsync(user);

        return new AuthResult
        {
            Succeeded = true,
            Token = newAccessToken,
            RefreshToken = newRefreshToken,
            TokenExpiration = tokenExpiration,
            Message = "Token refreshed successfully"
        };
    }

    public async Task RevokeTokenAsync(string username)
    {
        var user = await _userService.FindByNameAsync(username);
        if (user == null) throw new ArgumentException("Invalid username");

        user.RefreshToken = null;
        await _userService.UpdateAsync(user);
    }


    public async Task<AuthResult> ForgotPasswordAsync(string email)
    {
        var user = await _userService.FindByEmailAsync(email);
        if (user == null)
        {
            return new AuthResult { Succeeded = true, Message = "If that email address is in our system, we have sent a password reset link to it." };
        }

        var token = await _userService.GeneratePasswordResetTokenAsync(user);
        var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
        var callbackUrl = $"{_configuration["AppUrl"]}/api/Auth/reset-password?email={email}&token={encodedToken}";

        await _emailService.SendEmailAsync(email, "Reset Password",
            $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        return new AuthResult { Succeeded = true, Message = "If that email address is in our system, we have sent a password reset link to it." };
    }

    public async Task<AuthResult> ResetPasswordAsync(string email, string token, string newPassword)
    {
        var user = await _userService.FindByEmailAsync(email);
        if (user == null)
        {
            return new AuthResult { Succeeded = false, Message = "Password reset failed." };
        }

        var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
        var result = await _userService.ResetPasswordAsync(user, decodedToken, newPassword);

        if (result.Succeeded)
        {
            return new AuthResult { Succeeded = true, Message = "Password has been reset successfully." };
        }

        return new AuthResult { Succeeded = false, Errors = result.Errors.Select(e => e.Description) };
    }

    public async Task<AuthResult> ChangePasswordAsync(string username, string currentPassword, string newPassword)
    {
        var user = await _userService.FindByNameAsync(username);
        if (user == null)
        {
            return new AuthResult { Succeeded = false, Message = "ApplicationUser not found." };
        }

        var result = await _userService.ChangePasswordAsync(user, currentPassword, newPassword);

        if (result.Succeeded)
        {
            return new AuthResult { Succeeded = true, Message = "Password changed successfully." };
        }

        return new AuthResult { Succeeded = false, Errors = result.Errors.Select(e => e.Description) };
    }

    public async Task<AuthResult> ConfirmEmailAsync(string userId, string token)
    {
        var user = await _userService.FindByIdAsync(userId);
        if (user == null)
        {
            return new AuthResult { Succeeded = false, Message = "ApplicationUser not found." };
        }

        var decodedToken = Uri.UnescapeDataString(token);
        var result = await _userService.ConfirmEmailAsync(user, decodedToken);

        if (result.Succeeded)
        {
            return new AuthResult { Succeeded = true, Message = "Thank you for confirming your email." };
        }

        return new AuthResult { Succeeded = false, Message = "Email confirmation failed." };
    }

    public async Task<AuthResult> ResendEmailConfirmationAsync(string email)
    {
        var user = await _userService.FindByEmailAsync(email);
        if (user == null)
        {
            return new AuthResult { Succeeded = true, Message = "If that email address is in our system, we have sent a confirmation link to it." };
        }

        if (await _userService.IsEmailConfirmedAsync(user))
        {
            return new AuthResult { Succeeded = false, Message = "This email is already confirmed." };
        }

        var token = await _userService.GenerateEmailConfirmationTokenAsync(user);
        var encodedToken =  Uri.EscapeDataString(token);
        var callbackUrl = $"{_configuration["AppUrl"]}/api/auth/confirm-email?userId={user.Id}&token={encodedToken}";

        await _emailService.SendEmailAsync(email, "Confirm your email",
            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        return new AuthResult { Succeeded = true, Message = "Verification email sent. Please check your email." };
    }
}
