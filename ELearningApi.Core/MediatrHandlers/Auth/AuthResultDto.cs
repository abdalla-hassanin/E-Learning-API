namespace ELearningApi.Core.MediatrHandlers.Auth;

public class AuthResultDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime TokenExpiration { get; set; }
}
