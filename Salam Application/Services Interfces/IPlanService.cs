using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs;

namespace Salam_Application.Services_Interfces
{
    public interface IPlanService
    {
        Task<List<PlanDto>> GetAllPlans();
        Task<PlanDto> GetPlanById(int id);
        Task<string> AddPlan(PlanDto dto);
        Task<string> UpdatePlan(int id, PlanDto dto);
        Task<string> DeletePlan(int id);
    }
}