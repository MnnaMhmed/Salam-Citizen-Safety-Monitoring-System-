using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Salam_Application.DTOs.Profile;
using Salam_Application.Interfaces.Services;

namespace Salam_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile(int userId)
        {
            var profile = await _profileService.GetProfileAsync(userId);

            if (profile == null)
            {
                return NotFound(new
                {
                    message = "User not found"
                });
            }

            return Ok(profile);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateProfile(
            int userId,
            ProfileDto dto)
        {
            var profile = await _profileService
                .UpdateProfileAsync(userId, dto);

            if (profile == null)
            {
                return NotFound(new
                {
                    message = "User not found"
                });
            }

            return Ok(profile);
        }
    }
}