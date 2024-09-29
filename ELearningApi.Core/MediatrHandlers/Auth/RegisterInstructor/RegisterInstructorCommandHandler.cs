using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Entities;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.RegisterInstructor;

public class RegisterInstructorCommandHandler : IRequestHandler<RegisterInstructorCommand, ApiResponse<AuthResultDto>>
{
    private readonly IAuthService _authService;
    private readonly IInstructorService _instructorService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public RegisterInstructorCommandHandler(IAuthService authService, IInstructorService instructorService,
        IMapper mapper, ApiResponseHandler responseHandler)
    {
        _authService = authService;
        _instructorService = instructorService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<AuthResultDto>> Handle(RegisterInstructorCommand request,
        CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        var authResult = await _authService.RegisterUserAsync(user, request.Password, "Instructor");

        if (authResult.Succeeded)
        {
            var instructor = new Data.Entities.Instructor
            {
                UserId = user.Id,
                ApplicationUser = user,
                Expertise = request.Expertise,
                Biography = request.Biography
            };

            await _instructorService.CreateInstructorAsync(instructor, cancellationToken);
            var authResultDto = _mapper.Map<AuthResultDto>(authResult);
            return _responseHandler.Success(authResultDto, "Instructor registered successfully.");
        }

        return _responseHandler.BadRequest<AuthResultDto>(string.Join(", ", authResult.Errors));
    }
}