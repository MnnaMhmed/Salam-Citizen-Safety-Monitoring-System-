using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Salam_Application.Interfaces.Services
{
    public interface INotificationSender
    {
        Task SendNotificationAsync(int userId, string message);
    }
}