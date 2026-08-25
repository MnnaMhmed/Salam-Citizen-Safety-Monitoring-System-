using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Salam_Application.DTOs;
using Salam_Application.Services_Interfces;

namespace Salam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmergencyNumberController : ControllerBase
    {
        private readonly IEmergencyNumberService _emergencyNumberService;

        public EmergencyNumberController(IEmergencyNumberService emergencyNumberService)
        {
            _emergencyNumberService = emergencyNumberService;
        }

        [HttpGet("GetAllNumbers")]
        public async Task<IActionResult> GetAllNumbers()
        {
            var result = await _emergencyNumberService.GetAllNumbers();

            return Ok(result);
        }

        [HttpPost("AddNumber")]
        public async Task<IActionResult> AddNumber(EmergencyNumberDto dto)
        {
            var result = await _emergencyNumberService.AddNumber(dto);

            return Ok(result);
        }

        [HttpPut("UpdateNumber")]
        public async Task<IActionResult> UpdateNumber(EmergencyNumberDto dto)
        {
            var result = await _emergencyNumberService.UpdateNumber(dto);

            return Ok(result);
        }

        [HttpDelete("DeleteNumber")]
        public async Task<IActionResult> DeleteNumber(int id)
        {
            var result = await _emergencyNumberService.DeleteNumber(id);

            return Ok(result);
        }
    }
}