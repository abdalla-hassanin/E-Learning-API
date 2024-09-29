using ELearningApi.Service.Base;
using ELearningApi.Service.IService;
using ELearningApi.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ELearningApi.Service;

public static class ModuleServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        
        // Register Entity Services
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IEnrollmentService, EnrollmentService>();
        services.AddScoped<IInstructorService, InstructorService>();
        services.AddScoped<ILectureService, LectureService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IProgressService, ProgressService>();
        services.AddScoped<IQuizAttemptService, QuizAttemptService>();
        services.AddScoped<IQuizService, QuizService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<ISearchService, SearchService>();
        services.AddScoped<ISectionService, SectionService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IAuthService,AuthService>();
        services.AddScoped<ITokenService,TokenService>();
        return services;
    }
}