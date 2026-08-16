using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Salam_Application.DTOs;
using Salam_Application.Services_Interfces;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;

namespace Salam_Application.Services
{
    public class NotificationService : INotificationService
    {

        private readonly IUnitOfWork _unitOfWork;
        public NotificationService( IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        async Task<string> INotificationService.CreateNotification(NotificationDto ndto, int userid)
        {
            if (ndto == null)
                return "Please Enter All Notification Details! ";

                var not = new Notification
                {
                    Title = ndto.Title,
                    Content=ndto.Message,
                    CreatedAt=  DateTime.Now,
                    UserId=userid,


                };
           await _unitOfWork.Notifications.AddAsync(not);
            await _unitOfWork.SaveChangesAsync();
                return "Notification Created Successfully";
                

            

        }

        async Task<string> INotificationService.DeleteNotification(int id)
        {
          var not= await  _unitOfWork.Notifications.GetByIdAsync(id);
            if (not == null) return "Notification Not Found Aslan!";
            
                 _unitOfWork.Notifications.DeleteAsync(not);
            await _unitOfWork.SaveChangesAsync();
            return "Notification Deleted Successfully";

        }

        async Task<List<NotificationDto>> INotificationService.GetUserNotifications(int userid)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userid);

            if (user == null)
                return new List<NotificationDto>();

            var nots = await _unitOfWork.Notifications.GetAllAsync();

            var userNotifications = nots
                .Where(a => a.UserId == userid)
                .Select(a => new NotificationDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Message = a.Content,
                    CreatedAt = a.CreatedAt,
                    IsRead = a.IsRead
                })
                .ToList();

            return userNotifications;
        }

        async Task<bool> INotificationService.MarkAsRead(int notid)
        {

           var not= await  _unitOfWork.Notifications.GetByIdAsync(notid);
            if(not == null) return false;
            not.IsRead = true;
            await _unitOfWork.SaveChangesAsync();
            return true;

        }
    }
}
