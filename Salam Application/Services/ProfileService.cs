using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs.Profile;
using Salam_Application.Interfaces.Services;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;

namespace Salam_Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProfileDto> GetProfileAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            return new ProfileDto
            {
                Id = user.Id,
                FullName = user.FullName,
                NationalId = user.NationalId,
                PhoneNumber = user.PhoneNumber,
                BloodType = user.BloodType,
                AccountType = user.AccountType,
                IsDeaf = user.IsDeaf
            };
        }

        public async Task<ProfileDto> UpdateProfileAsync(
            int userId,
           ProfileDto dto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            user.FullName = dto.FullName;
            user.PhoneNumber = dto.PhoneNumber;
            user.BloodType = dto.BloodType;
            user.IsDeaf = dto.IsDeaf;

            _unitOfWork.Users.UpdateAsync(user);

            await _unitOfWork.SaveChangesAsync();

            return new ProfileDto
            {
                Id = user.Id,
                FullName = user.FullName,
                NationalId = user.NationalId,
                PhoneNumber = user.PhoneNumber,
                BloodType = user.BloodType,
                AccountType = user.AccountType,
                IsDeaf = user.IsDeaf
            };
        }
    }
}