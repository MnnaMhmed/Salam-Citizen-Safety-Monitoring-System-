using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Salam_Application.DTOs;
using Salam_Application.Services_Interfces;

namespace Salam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpGet("GetAllPlans")]
        public async Task<IActionResult> GetAllPlans()
        {
            var plans = await _planService.GetAllPlans();
            return Ok(plans);
        }

        [HttpGet("GetPlanById")]
        public async Task<IActionResult> GetPlanById(int id)
        {
            var plan = await _planService.GetPlanById(id);

            if (plan == null)
                return NotFound("Plan Not Found");

            return Ok(plan);
        }

        [HttpPost("AddPlan")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPlan(PlanDto dto)
        {
            var result = await _planService.AddPlan(dto);
            return Ok(result);
        }

        [HttpPut("UpdatePlan")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePlan(int id, PlanDto dto)
        {
            var result = await _planService.UpdatePlan(id, dto);
            return Ok(result);
        }

        [HttpDelete("DeletePlan")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePlan(int id)
        {
            var result = await _planService.DeletePlan(id);
            return Ok(result);
        }
    }
}