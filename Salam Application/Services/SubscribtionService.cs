using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.Services_Interfces;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;

namespace Salam_Application.Services
{
    public class SubscribtionService : ISubscribtionService
    {

        private readonly IUnitOfWork _unitOfWork;
        public SubscribtionService( IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
     async   Task<List<Plan>> ISubscribtionService.GetAllPlans()
        {

            var plans= await _unitOfWork.Plan.GetAllAsync();
            return (plans.ToList());
        }

        async Task<List<Subscribtion>> ISubscribtionService.GetAllSubscribtion()
        {
            var Subs = await _unitOfWork.Subscribtions.GetAllAsync();
            return (Subs.ToList());
        }
        async Task<List<Subscribtion>> ISubscribtionService.GetUserSubscribtion(int userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user == null)
                return new List<Subscribtion>();

            var userSubs = await _unitOfWork.Subscribtions.GetAllAsync();

            return userSubs
                .Where(s => s.UserId == userId)
                .ToList();
        }

        async Task<bool> ISubscribtionService.IsActive(int userId)
        {


            var user =await  _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                return false;

            var subs = await _unitOfWork.Subscribtions.GetAllAsync();

          var isactive= subs.FirstOrDefault
                (a=>a.UserId == userId && a.IsActive&&a.EndDate>DateTime.Now);


            return isactive != null;
        }

       async  Task<string> ISubscribtionService.Subscribe(int userId, int planId)
        {

            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                return ("User Not Found");

            var plan = await _unitOfWork.Plan.GetByIdAsync(planId);
            if (plan == null)
                return ("There is no Plan like This -_-");

            var sub = new Subscribtion()
            {

                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays (plan.DurationInDays),
                IsActive = true,
                UserId = userId,
                PlanId = planId
            };
           await _unitOfWork.Subscribtions.AddAsync(sub);
          await  _unitOfWork.SaveChangesAsync();
            return ("User Subscibed Successfully to this Plan :)");
        }

        async Task<string> ISubscribtionService.Unsubscribe(
         int userId,
         int subscriptionId)
        {
            var sub = await _unitOfWork.Subscribtions.GetByIdAsync(subscriptionId);

            if (sub == null)
                return "Subscription not found";

            if (sub.UserId != userId)
                return "This subscription does not belong to this user";

            sub.IsActive = false;

            await _unitOfWork.SaveChangesAsync();

            return "Subscription cancelled successfully";
        }
    }
}
