using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Salam_Application.DTOs.Rating;
using Salam_Application.Interfaces.Services;

namespace Salam_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRating(
            RatingDto dto)
        {
            if (dto.Rate < 1 || dto.Rate > 5)
            {
                return BadRequest(new
                {
                    message = "Rate must be between 1 and 5"
                });
            }

            var result = await _ratingService
                .CreateRatingAsync(dto);

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
        public async Task<IActionResult> GetUserRatings(int userId)
        {
            var result = await _ratingService
                .GetUserRatingsAsync(userId);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "User not found"
                });
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            var result = await _ratingService
                .GetAllRatingsAsync();

            return Ok(result);
        }
    }
}