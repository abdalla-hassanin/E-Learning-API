using ELearningApi.Data.Entities;

namespace ELearningApi.Service.IService;

public interface IPaymentService
{
    Task<Payment> ProcessPaymentAsync(Guid studentId, Guid courseId, decimal amount, string paymentMethod);
    Task<Payment> GetPaymentByIdAsync(Guid paymentId);
    Task<Payment> RefundPaymentAsync(Guid paymentId);
    Task<IEnumerable<Payment>> GetPaymentHistoryAsync(Guid studentId);
    Task<string> GenerateInvoiceAsync(Guid paymentId);
    Task<bool> VerifyPaymentAsync(Guid paymentId);
}