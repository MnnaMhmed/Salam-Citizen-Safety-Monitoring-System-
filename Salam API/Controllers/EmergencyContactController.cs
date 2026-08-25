using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salam_Application.DTOs;
using Salam_Application.Services_Interfces;
using Salam_Domain.Entities;

namespace Salam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmergencyContactController : ControllerBase
    {
        private readonly IEmergencyContactsService _emergencyContactsService;
        public EmergencyContactController( IEmergencyContactsService emergencyContactsService)
        {
            _emergencyContactsService= emergencyContactsService;
        }

        [HttpGet ("GetAllUserConatcts")]
        public async Task <IActionResult> GetAllUserContacts (int Userid)
        {
            var contact= await _emergencyContactsService.GetAllUserContacts(Userid);
            return Ok(contact);

        }
        [HttpPost ("AddContact")]
        public async Task<IActionResult> AddContact(int userid,EmergencyContactDto econtactdto)
        {
            if (econtactdto == null)
                return BadRequest("Please Enter All Contact Data");
            await _emergencyContactsService.AddContact(userid, econtactdto);
            return Ok("Contact added Successfully");
        }
        [HttpDelete("Delete Contact")]

        public async Task<IActionResult> DeleteContatc(int eid)
        {
            if (eid == null)
                return BadRequest("Please Enter Vaild Id");
              await  _emergencyContactsService.DeleteContact(eid);
            return Ok("Contact Deleted Successfully");
        }
        [HttpPut("Update Contact")]

        public async Task<IActionResult> UpdateContatc(int eid , int userid, EmergencyContactDto updatedContact)
        {
        

            var contact =await _emergencyContactsService.UpdateContact(eid, updatedContact, userid);
            return Ok(contact);
        }



    }
}
