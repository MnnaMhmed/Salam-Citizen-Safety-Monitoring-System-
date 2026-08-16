using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs;
using Salam_Domain.Entities;

namespace Salam_Application.Services_Interfces
{
    public interface INotificationService
    {

        public Task<List<NotificationDto>> GetUserNotifications( int userid);
        public Task<string> CreateNotification(NotificationDto ndto , int userid);
        public Task<string> DeleteNotification(int id );
        public Task<bool> MarkAsRead(int notid);



    }
}
