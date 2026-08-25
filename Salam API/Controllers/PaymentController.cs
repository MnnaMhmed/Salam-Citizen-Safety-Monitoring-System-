using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Salam_Application.DTOs.Payment;
using Salam_Application.Interfaces.Services;

namespace Salam_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(
            PaymentDto dto)
        {
            var result = await _paymentService
                .CreatePaymentAsync(dto);

            if (result == null)
            {
                return BadRequest(new
                {
                    message = "Invalid user, subscription or plan"
                });
            }

            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserPayments(
            int userId)
        {
            var result = await _paymentService
                .GetUserPaymentsAsync(userId);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "User not found"
                });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var result = await _paymentService
                .GetPaymentByIdAsync(id);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Payment not found"
                });
            }

            return Ok(result);
        }
    }
}