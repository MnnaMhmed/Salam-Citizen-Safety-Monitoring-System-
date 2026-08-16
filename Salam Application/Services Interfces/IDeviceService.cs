using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs;
using Salam_Domain.Entities;

namespace Salam_Application.Services_Interfces
{
    public interface IDeviceService
    {
        public Task<bool> AddDevice(DeviceDto Ddto, int id);
        public Task<List<Device>> GetUserDevices(int id);
        public Task<List<Device>> GetAllDevices();
        public Task DeleteDevice(int Did);

    }
}
