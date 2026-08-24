using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs.Rating;
using Salam_Application.Interfaces.Services;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;

namespace Salam_Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RatingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RatingDto> CreateRatingAsync(
            RatingDto dto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(dto.UserId);

            if (user == null)
            {
                return null;
            }

            if (dto.Rate < 1 || dto.Rate > 5)
            {
                return null;
            }

            var rating = new Rating
            {
                UserId = dto.UserId,
                Rate = dto.Rate,
                Comment = dto.Comment,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Ratings.AddAsync(rating);

            await _unitOfWork.SaveChangesAsync();

            return new RatingDto
            {
                Id = rating.Id,
                UserId = rating.UserId,
                Rate = rating.Rate,
                Comment = rating.Comment,
                CreatedAt = rating.CreatedAt
            };
        }

        public async Task<IEnumerable<RatingDto>> GetUserRatingsAsync(
            int userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            var ratings = await _unitOfWork.Ratings.GetAllAsync();

            return ratings
                .Where(x => x.UserId == userId)
                .Select(x => new RatingDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Rate = x.Rate,
                    Comment = x.Comment,
                    CreatedAt = x.CreatedAt
                })
                .ToList();
        }

        public async Task<IEnumerable<RatingDto>> GetAllRatingsAsync()
        {
            var ratings = await _unitOfWork.Ratings.GetAllAsync();

            return ratings
                .Select(x => new RatingDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Rate = x.Rate,
                    Comment = x.Comment,
                    CreatedAt = x.CreatedAt
                })
                .ToList();
        }
    }
}