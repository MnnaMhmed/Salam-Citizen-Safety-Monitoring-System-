using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs.Support;
using Salam_Application.Interfaces.Services;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;

namespace Salam_Application.Services
{
    public class SupportService : ISupportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SupportDto> CreateSupportRequestAsync(
            SupportDto dto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(dto.UserId);

            if (user == null)
            {
                return null;
            }

            var support = new Support
            {
                UserId = dto.UserId,
                Subject = dto.Subject,
                Message = dto.Message,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Supports.AddAsync(support);

            await _unitOfWork.SaveChangesAsync();

            return new SupportDto
            {
                Id = support.Id,
                UserId = support.UserId,
                Subject = support.Subject,
                Message = support.Message,
                Status = support.Status,
                CreatedAt = support.CreatedAt
            };
        }

        public async Task<IEnumerable<SupportDto>> GetUserSupportRequestsAsync(
            int userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            var supports = await _unitOfWork.Supports.GetAllAsync();

            var userSupports = supports
                .Where(x => x.UserId == userId)
                .Select(x => new SupportDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Subject = x.Subject,
                    Message = x.Message,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt
                })
                .ToList();

            return userSupports;
        }

        public async Task<SupportDto> GetSupportRequestByIdAsync(int id)
        {
            var support = await _unitOfWork.Supports.GetByIdAsync(id);

            if (support == null)
            {
                return null;
            }

            return new SupportDto
            {
                Id = support.Id,
                UserId = support.UserId,
                Subject = support.Subject,
                Message = support.Message,
                Status = support.Status,
                CreatedAt = support.CreatedAt
            };
        }
    }
}