using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Salam_API.Hubs;
using Salam_Application.Interfaces.Services;

namespace Salam_API.Services
{
    public class SignalRNotificationSender : INotificationSender
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public SignalRNotificationSender(
            IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotificationAsync(
            int userId,
            string message)
        {
            await _hubContext.Clients
                .Group($"user-{userId}")
                .SendAsync("ReceiveNotification", new
                {
                    UserId = userId,
                    Message = message,
                    CreatedAt = DateTime.UtcNow
                });
        }
    }
}