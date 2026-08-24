using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Salam_Application.DTOs.Payment
{
    public class PaymentDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int SubscriptionId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public string TransactionId { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}