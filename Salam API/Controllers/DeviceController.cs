using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salam_Application.DTOs;
using Salam_Application.Services_Interfces;

namespace Salam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {

      
            private readonly IDeviceService _deviceService;

            public DeviceController(IDeviceService deviceService)
            {
            _deviceService = deviceService;
            }


            [HttpGet("GetAllDevices")]
            public async Task<IActionResult> GetAllDevices()
            {
                var devs = await _deviceService.GetAllDevices();
                return Ok(devs);
            }

            [HttpPost("AddDevice")]
            public async Task<IActionResult> AddDevice(int userid, [FromBody] DeviceDto Ddto)
            {
                await _deviceService.AddDevice(Ddto, userid);
                return Ok("Device Has been Sucessfully Added");
            }


            [HttpGet("GetUserDevices")]
            public async Task<IActionResult> GetUserDevices(int userid)
            {
                var Devs = await _deviceService.GetUserDevices(userid);
                return Ok(Devs.ToList());
            }

     
            [HttpDelete("DeletDevice")]
            public async Task<ActionResult> DeleteDevice(int id)
            {
                await _deviceService.DeleteDevice(id);
                return Ok("Device Deleted Successfully");
            }




        }
    }

