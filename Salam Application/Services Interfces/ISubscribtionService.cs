using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Domain.Entities;

namespace Salam_Application.Services_Interfces
{
    public interface ISubscribtionService
    {
        Task<List<Subscribtion>> GetAllSubscribtion();

        Task<List<Plan>> GetAllPlans();

        Task<string> Subscribe(int userId, int planId);

        Task<string> Unsubscribe(int userId, int subscriptionId);

        Task<List<Subscribtion>> GetUserSubscribtion(int userId);

        Task<bool> IsActive(int userId);
    }
}
