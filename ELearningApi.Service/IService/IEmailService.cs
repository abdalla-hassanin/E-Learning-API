namespace ELearningApi.Service.IService;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string body);
}