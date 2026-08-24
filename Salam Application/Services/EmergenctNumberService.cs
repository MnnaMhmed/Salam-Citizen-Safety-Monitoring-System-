using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs;
using Salam_Application.Services_Interfces;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;

namespace Salam_Application.Services
{
    public class EmergencyNumberService : IEmergencyNumberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmergencyNumberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<EmergencyNumberDto>> GetAllNumbers()
        {
            var numbers = await _unitOfWork.EmergencyNumbers.GetAllAsync();

            return numbers.Select(n => new EmergencyNumberDto
            {
                Id = n.Id,
                Name = n.Name,
                PhoneNumber = n.PhoneNumber,
                Description = n.Description
            }).ToList();
        }

        public async Task<string> AddNumber(EmergencyNumberDto dto)
        {
            if (dto == null)
                return "Please Enter Emergency Number Details";

            var number = new EmergencyNumber
            {
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                Description = dto.Description
            };

            await _unitOfWork.EmergencyNumbers.AddAsync(number);
            await _unitOfWork.SaveChangesAsync();

            return "Emergency Number Added Successfully";
        }

        public async Task<string> UpdateNumber(EmergencyNumberDto dto)
        {
            var number = await _unitOfWork.EmergencyNumbers.GetByIdAsync(dto.Id);

            if (number == null)
                return "Emergency Number Not Found";

            number.Name = dto.Name;
            number.PhoneNumber = dto.PhoneNumber;
            number.Description = dto.Description;

            _unitOfWork.EmergencyNumbers.UpdateAsync(number);
            await _unitOfWork.SaveChangesAsync();

            return "Emergency Number Updated Successfully";
        }

        public async Task<string> DeleteNumber(int id)
        {
            var number = await _unitOfWork.EmergencyNumbers.GetByIdAsync(id);

            if (number == null)
                return "Emergency Number Not Found";

            _unitOfWork.EmergencyNumbers.DeleteAsync(number);
            await _unitOfWork.SaveChangesAsync();

            return "Emergency Number Deleted Successfully";
        }
    }
}