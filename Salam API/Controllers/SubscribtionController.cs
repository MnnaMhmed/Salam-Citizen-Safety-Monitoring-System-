using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salam_Application.Services;
using Salam_Application.Services_Interfces;
namespace Salam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribtionController : ControllerBase
    {
        private readonly ISubscribtionService _subscribtionService;
        public SubscribtionController(ISubscribtionService subscribtionService)
        {
            _subscribtionService = subscribtionService;
        }

        [HttpGet("GetAllPlans")]
        public async Task<IActionResult> ShowAllPlans()
        {
            var plans = await _subscribtionService.GetAllPlans();
            return Ok(plans);
        }

        [HttpPost("Subscribe")]
        public async Task<IActionResult> Subscribe(int userId, int planId)
        {
            var result = await _subscribtionService.Subscribe(userId, planId);

            return Ok(result);
        }

        [HttpGet("GetAllSubscribtions")]
        public async Task<IActionResult> GetAllSubscribtions()
        {
            var subs = await _subscribtionService.GetAllSubscribtion();
            return Ok(subs);
        }


        [HttpGet("Get_User_Subscribtions")]
        public async Task<IActionResult> GetUserSubscribtions(int userid)
        {
            var subs = await _subscribtionService.GetUserSubscribtion(userid);
            return Ok(subs);
        }

        [HttpPost("UnSubscribe")]
        public async Task<IActionResult> UnSubscribe(int userId, int subid)
        {
            await _subscribtionService.Unsubscribe(userId, subid);

            return Ok("User Unsubsribed Successfully ");
        }

        [HttpGet("IsSubActive")]
        public async Task<IActionResult> IsSubActive(int userId)
        {
            var result = await _subscribtionService.IsActive(userId);

            return Ok(result);
        }



    }
    }
