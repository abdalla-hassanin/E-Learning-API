using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Entities;
using ELearningApi.Service.Base;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Auth.RegisterStudent;

public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, ApiResponse<AuthResultDto>>
{
    private readonly IAuthService _authService;
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public RegisterStudentCommandHandler(IAuthService authService, IStudentService studentService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _authService = authService;
        _studentService = studentService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<AuthResultDto>> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
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
        var authResult = await _authService.RegisterUserAsync(user, request.Password, "Student");

        if (authResult.Succeeded)
        {
            var student = new Data.Entities.Student
            {
                UserId = user.Id,
                ApplicationUser = user
            };

            await _studentService.CreateStudentAsync(student, cancellationToken);
            var authResultDto = _mapper.Map<AuthResultDto>(authResult);
            return _responseHandler.Success(authResultDto, "Student registered successfully.");
        }

        return _responseHandler.BadRequest<AuthResultDto>(string.Join(", ", authResult.Errors));
    }
}

