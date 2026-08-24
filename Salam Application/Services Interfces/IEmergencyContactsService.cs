using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Domain.Entities;
using Salam_Application.DTOs;


namespace Salam_Application.Services_Interfces
{
    public interface IEmergencyContactsService
    {
        public  Task<List<EmergencyContactDto>> GetAllUserContacts(int userid);
        public  Task AddContact(int userid,EmergencyContactDto econtact);
        public  Task<string> UpdateContact(int contactid, EmergencyContactDto updatedcontact, int userid);
        public  Task DeleteContact(int eid);

    }
}
