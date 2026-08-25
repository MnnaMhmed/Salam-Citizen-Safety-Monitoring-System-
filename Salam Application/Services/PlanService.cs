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
    public class PlanService : IPlanService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PlanDto>> GetAllPlans()
        {
            var plans = await _unitOfWork.Plans.GetAllAsync();

            return plans.Select(p => new PlanDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Duration = p.Duration
            }).ToList();
        }

        public async Task<PlanDto> GetPlanById(int id)
        {
            var plan = await _unitOfWork.Plans.GetByIdAsync(id);

            if (plan == null)
                return null;

            return new PlanDto
            {
                Id = plan.Id,
                Name = plan.Name,
                Price = plan.Price,
                Duration = plan.Duration
            };
        }

        public async Task<string> AddPlan(PlanDto dto)
        {
            if (dto == null)
                return "Please Enter Plan Data";

            var plan = new Plan
            {
                Name = dto.Name,
                Price = dto.Price,
                Duration = dto.Duration
            };

            await _unitOfWork.Plans.AddAsync(plan);
            await _unitOfWork.SaveChangesAsync();

            return "Plan Added Successfully";
        }

        public async Task<string> UpdatePlan(int id, PlanDto dto)
        {
            var plan = await _unitOfWork.Plans.GetByIdAsync(id);

            if (plan == null)
                return "Plan Not Found";

            plan.Name = dto.Name;
            plan.Price = dto.Price;
            plan.Duration = dto.Duration;

            _unitOfWork.Plans.UpdateAsync(plan);
            await _unitOfWork.SaveChangesAsync();

            return "Plan Updated Successfully";
        }

        public async Task<string> DeletePlan(int id)
        {
            var plan = await _unitOfWork.Plans.GetByIdAsync(id);

            if (plan == null)
                return "Plan Not Found";

            _unitOfWork.Plans.DeleteAsync(plan);
            await _unitOfWork.SaveChangesAsync();

            return "Plan Deleted Successfully";
        }
    }
}