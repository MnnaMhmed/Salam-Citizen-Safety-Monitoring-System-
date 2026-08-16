using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Domain.Entities;

namespace Salam_Application.Services_Interfces
{
    public interface IEmergencyContactsService
    {
        public  Task<List<EmergencyContact>> GetAllUserContacts(int userid);
        public  Task AddContact(EmergencyContact econtact);
        public  Task<string> UpdateContact(int contactid, EmergencyContact updatedcontact, int userid);
        public  Task DeleteContact(int eid);

    }
}
