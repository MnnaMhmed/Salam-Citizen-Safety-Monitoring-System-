using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Salam_Application.DTOs.Payment;

namespace Salam_Application.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<PaymentDto> CreatePaymentAsync(PaymentDto dto);

        Task<IEnumerable<PaymentDto>> GetUserPaymentsAsync(int userId);

        Task<PaymentDto> GetPaymentByIdAsync(int id);
    }
}