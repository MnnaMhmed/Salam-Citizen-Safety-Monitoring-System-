using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs.Payment;
using Salam_Application.Interfaces.Services;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;

namespace Salam_Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaymentDto> CreatePaymentAsync(
            PaymentDto dto)
        {
            var user = await _unitOfWork.Users
                .GetByIdAsync(dto.UserId);

            if (user == null)
            {
                return null;
            }

            var subscription = await _unitOfWork.Subscribtions
                .GetByIdAsync(dto.SubscriptionId);

            if (subscription == null ||
                subscription.UserId != dto.UserId)
            {
                return null;
            }

            var plan = await _unitOfWork.Plan
                .GetByIdAsync(subscription.PlanId);

            if (plan == null)
            {
                return null;
            }

            var payment = new Payment
            {
                UserId = dto.UserId,
                SubscriptionId = dto.SubscriptionId,
                Amount = plan.Price,
                PaymentMethod = dto.PaymentMethod,
                TransactionId = dto.TransactionId,
                Status = "Paid",
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Payments.AddAsync(payment);

            await _unitOfWork.SaveChangesAsync();

            return new PaymentDto
            {
                Id = payment.Id,
                UserId = payment.UserId,
                SubscriptionId = payment.SubscriptionId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                TransactionId = payment.TransactionId,
                Status = payment.Status,
                CreatedAt = payment.CreatedAt
            };
        }

        public async Task<IEnumerable<PaymentDto>> GetUserPaymentsAsync(
            int userId)
        {
            var user = await _unitOfWork.Users
                .GetByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            var payments = await _unitOfWork.Payment
                .GetAllAsync();

            return payments
                .Where(x => x.UserId == userId)
                .Select(x => new PaymentDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    SubscriptionId = x.SubscriptionId,
                    Amount = x.Amount,
                    PaymentMethod = x.PaymentMethod,
                    TransactionId = x.TransactionId,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt
                })
                .ToList();
        }

        public async Task<PaymentDto> GetPaymentByIdAsync(int id)
        {
            var payment = await _unitOfWork.Payment
                .GetByIdAsync(id);

            if (payment == null)
            {
                return null;
            }

            return new PaymentDto
            {
                Id = payment.Id,
                UserId = payment.UserId,
                SubscriptionId = payment.SubscriptionId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                TransactionId = payment.TransactionId,
                Status = payment.Status,
                CreatedAt = payment.CreatedAt
            };
        }
    }
}