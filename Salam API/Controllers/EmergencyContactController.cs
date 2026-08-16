using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salam_Application.Services_Interfces;
using Salam_Domain.Entities;

namespace Salam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var contacts= await _emergencyContactsService.GetAllUserContacts(Userid);
            return Ok(contacts);

        }
        [HttpPost ("AddContact")]
        public async Task<IActionResult> AddContact(EmergencyContact econtact)
        {
            if (econtact == null)
                return BadRequest("Please Enter All Contact Data");

            var contacts =  _emergencyContactsService.AddContact(econtact);
            return Ok("Contact added Successfully");
        }

        public async Task<IActionResult> DeleteContatc(int eid)
        {
            if (eid == null)
                return BadRequest("Please Enter Vaild Id");
              await  _emergencyContactsService.DeleteContact(eid);
            return Ok("Contact Deleted Successfully");
        }
        public async Task<IActionResult> UpdateContatc(int eid , int userid, EmergencyContact updatedContact)
        {
        

            var contact =await _emergencyContactsService.UpdateContact(eid, updatedContact, userid);
            return Ok(contact);
        }



    }
}
