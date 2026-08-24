using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Salam_Application.DTOs;

namespace Salam_Application.Services_Interfces
{
    public interface IEmergencyNumberService
    {
        Task<List<EmergencyNumberDto>> GetAllNumbers();

        Task<string> AddNumber(EmergencyNumberDto dto);

        Task<string> UpdateNumber(EmergencyNumberDto dto);

        Task<string> DeleteNumber(int id);
    }
}