using System.Security.Claims;

namespace ELearningApi.Service.IService;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    int GetAccessTokenExpirationMinutes();

}
