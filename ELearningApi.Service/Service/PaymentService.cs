using ELearningApi.Data.Entities;
using ELearningApi.Data.Enums;
using ELearningApi.Infrustructure.Base;
using ELearningApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace ELearningApi.Service.Service;

 public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Payment> ProcessPaymentAsync(Guid studentId, Guid courseId, decimal amount, string paymentMethod)
        {
            var payment = new Payment
            {
                StudentId = studentId,
                CourseId = courseId,
                Amount = amount,
                Method = paymentMethod,
                Status = PaymentStatus.Pending,
                PaymentReferenceId = GeneratePaymentReferenceId()
            };

            await _unitOfWork.Repository<Payment>().AddAsync(payment);

            // Simulate payment processing
            // In a real-world scenario, you would integrate with a payment gateway here
            await Task.Delay(1000); // Simulating external API call

            payment.Status = PaymentStatus.Completed;
            await _unitOfWork.CompleteAsync();

            return payment;
        }

        public async Task<Payment> GetPaymentByIdAsync(Guid paymentId)
        {
            var payment = await _unitOfWork.Repository<Payment>()
                .Find(p => p.Id == paymentId)
                .Include(p => p.Student)
                .Include(p => p.Course)
                .FirstOrDefaultAsync();

            if (payment == null)
                throw new ArgumentException("Payment not found", nameof(paymentId));
            
            return payment;
        }

        public async Task<Payment> RefundPaymentAsync(Guid paymentId)
        {
            var payment = await GetPaymentByIdAsync(paymentId);

            if (payment == null)
            {
                throw new ArgumentException("Payment not found", nameof(paymentId));
            }

            if (payment.Status != PaymentStatus.Completed)
            {
                throw new InvalidOperationException("Only completed payments can be refunded");
            }

            // Simulate refund processing
            // In a real-world scenario, you would integrate with a payment gateway here
            await Task.Delay(1000); // Simulating external API call

            payment.Status = PaymentStatus.Refunded;
            await _unitOfWork.CompleteAsync();

            return payment;
        }

        public async Task<IEnumerable<Payment>> GetPaymentHistoryAsync(Guid studentId)
        {
            return await _unitOfWork.Repository<Payment>()
                .Find(p => p.StudentId == studentId)
                .Include(p => p.Course)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<string> GenerateInvoiceAsync(Guid paymentId)
        {
            var payment = await GetPaymentByIdAsync(paymentId);

            if (payment == null)
            {
                throw new ArgumentException("Payment not found", nameof(paymentId));
            }

            // In a real-world scenario, you would generate a proper invoice here
            // This is a simplified version
            var invoice = $"Invoice for Payment {payment.PaymentReferenceId}\n" +
                          $"Date: {payment.CreatedAt}\n" +
                          $"Student: {payment.Student.ApplicationUser.UserName}\n" +
                          $"Course: {payment.Course.Title}\n" +
                          $"Amount: {payment.Amount:C}\n" +
                          $"Status: {payment.Status}";

            return invoice;
        }

        public async Task<bool> VerifyPaymentAsync(Guid paymentId)
        {
            var payment = await GetPaymentByIdAsync(paymentId);

            if (payment == null)
            {
                throw new ArgumentException("Payment not found", nameof(paymentId));
            }

            // In a real-world scenario, you might need to check with the payment gateway
            // This is a simplified version
            return payment.Status == PaymentStatus.Completed;
        }

        private string GeneratePaymentReferenceId()
        {
            return $"PAY-{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";
        }
    }