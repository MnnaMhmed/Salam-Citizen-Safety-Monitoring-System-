using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs.Support;

namespace Salam_Application.Interfaces.Services
{
    public interface ISupportService
    {
        Task<SupportDto> CreateSupportRequestAsync(SupportDto dto);

        Task<IEnumerable<SupportDto>> GetUserSupportRequestsAsync(int userId);

        Task<SupportDto> GetSupportRequestByIdAsync(int id);
    }
}