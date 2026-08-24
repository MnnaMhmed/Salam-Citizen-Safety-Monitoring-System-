using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Salam_Application.DTOs.Profile;

namespace Salam_Application.Interfaces.Services
{
    public interface IProfileService
    {
        Task<ProfileDto> GetProfileAsync(int userId);

        Task<ProfileDto> UpdateProfileAsync(int userId,ProfileDto dto);
    }
}