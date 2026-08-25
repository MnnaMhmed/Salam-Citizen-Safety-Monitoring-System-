using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Salam_Application.DTOs.Support;
using Salam_Application.Interfaces.Services;

namespace Salam_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    [Authorize]
    public class SupportController : ControllerBase
    {
        private readonly ISupportService _supportService;

        public SupportController(ISupportService supportService)
        {
            _supportService = supportService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupportRequest(
            SupportDto dto)
        {
            var result = await _supportService
                .CreateSupportRequestAsync(dto);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "User not found"
                });
            }

            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserSupportRequests(
            int userId)
        {
            var result = await _supportService
                .GetUserSupportRequestsAsync(userId);

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
        public async Task<IActionResult> GetSupportRequestById(int id)
        {
            var result = await _supportService
                .GetSupportRequestByIdAsync(id);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Support request not found"
                });
            }

            return Ok(result);
        }
    }
}