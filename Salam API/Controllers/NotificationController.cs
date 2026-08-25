using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salam_Application.DTOs;
using Salam_Application.Services;
using Salam_Application.Services_Interfces;
using Salam_Domain.Entities;
namespace Salam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController( INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpGet ("GetUserNotifications")]
        public async  Task <IActionResult> GetUserNotifications (int userid)
        {
            var nots= await _notificationService.GetUserNotifications (userid);
            return (Ok (nots));
        }


        [HttpPost ("Create Notification")]
        public async Task<IActionResult> CreateNotification(NotificationDto ndto, int userid)
        {
            var result=await _notificationService.CreateNotification(ndto, userid);
            return Ok(result);

        }



        [HttpDelete ("Delete Notification")]
        public async Task<IActionResult> DeleteNotification(int nid)
        {
            var result = await _notificationService.DeleteNotification(nid);
            return Ok(result);
        }

        [HttpPost ("Mark As Read")]
        public async Task<IActionResult> MarkAsRead(int nid)
        {
            var result= await _notificationService.MarkAsRead(nid);
            return Ok(result);
        }


    }
}
