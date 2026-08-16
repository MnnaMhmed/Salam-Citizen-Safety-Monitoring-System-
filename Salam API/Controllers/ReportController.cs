using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salam_Application.DTOs;
using Salam_Application.Services;
using Salam_Application.Services_Interfces;

namespace Salam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
            
        }


        [HttpGet("GetAllReports")]
        public async Task<IActionResult> GetAllReports()
        {
            var reps = await _reportService.GetAllReports();
            return Ok(reps);
        }

        [HttpPost("AddReport")]
        public async Task<IActionResult> AddReport( int userid,ReportDto rdto)
        {
         await _reportService.AddReport(rdto, userid);
            return Ok("Report Has Sucessfully Added");
        }


        [HttpGet("GetUserReports")]
        public async Task<IActionResult> GetUserReports(int userid)
        {
            var reps=await _reportService.GetUserReports( userid);
            return Ok(reps);
        }

        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus( string status, int rid)
        {
            await _reportService.UpdateStatus(status, rid );
            
            return Ok("Report Updated Successfully");
        }

        [HttpDelete ("DeletReport")]
        public async Task <ActionResult> DeleteReport (int id)
        {
            await _reportService.DeleteReport(id);
            return Ok("Report Deleted Successfully");
        }




    }
}
