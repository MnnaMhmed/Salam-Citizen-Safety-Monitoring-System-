using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Salam_Application.DTOs.Rating;

namespace Salam_Application.Interfaces.Services
{
    public interface IRatingService
    {
        Task<RatingDto> CreateRatingAsync(RatingDto dto);

        Task<IEnumerable<RatingDto>> GetUserRatingsAsync(int userId);

        Task<IEnumerable<RatingDto>> GetAllRatingsAsync();
    }
}