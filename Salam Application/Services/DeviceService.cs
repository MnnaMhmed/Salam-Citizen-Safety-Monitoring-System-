using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs;
using Salam_Application.Services_Interfces;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;
using Xunit;

namespace Salam_Application.Services
{
    public class DeviceService:IDeviceService
    {


            private readonly IUnitOfWork _unitOfWork;
            public DeviceService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }


            async Task<bool> IDeviceService.AddDevice(DeviceDto Ddto, int id)
            {

             var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
                return false;


            var device = new Device
            {
                DeviceName = Ddto.DeviceName,
                SerialNumber = Ddto.SerialNumber,
                UserId = id,

            };
            await _unitOfWork.Devices.AddAsync(device);
                await _unitOfWork.SaveChangesAsync();
                return true;


            }


            async Task<List<Device>> IDeviceService.GetAllDevices()
            {
                var Devices = await _unitOfWork.Devices.GetAllAsync();
                return Devices.ToList();
            }

            async Task<List<Device>> IDeviceService.GetUserDevices(int id)
            {


                var devices = await _unitOfWork.Devices.GetAllAsync();
                return devices.Where(a => a.UserId == id).ToList();

            }

         
            async Task IDeviceService.DeleteDevice(int Did)
            {
                var Dev = await _unitOfWork.Devices.GetByIdAsync(Did);

                if (Dev == null)
                    throw new Exception("Device not found");

                _unitOfWork.Devices.DeleteAsync(Dev);

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }


