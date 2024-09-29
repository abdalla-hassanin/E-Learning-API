using AutoMapper;
using ELearningApi.Service.Base;

namespace ELearningApi.Core.MediatrHandlers.Auth;

public class AuthMappingProfile: Profile
{
    public AuthMappingProfile()
    {
        CreateMap<AuthResult, AuthResultDto>();
    }
}
