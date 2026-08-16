using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.Services_Interfces;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;

namespace Salam_Application.Services
{
    public class EmergencyContactsService : IEmergencyContactsService
    {

        private readonly IUnitOfWork _unitOfWork;
        public EmergencyContactsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  
        }
        async Task<List<EmergencyContact>> IEmergencyContactsService.GetAllUserContacts(int userid)
        {
            var user= await _unitOfWork.Users.GetByIdAsync(userid);
            if (user==null)
                return new List<EmergencyContact>();

            var econtact = await _unitOfWork.EmergencyContacts.GetAllAsync();
            return (econtact.Where(e => e.UserId == userid).ToList());
        }
        async Task IEmergencyContactsService.AddContact(EmergencyContact econtact)
        {
            if (econtact == null)
                return;
            var contact = new EmergencyContact
            {
                Id = econtact.Id,
                Name = econtact.Name,
                Phone = econtact.Phone,
                Relation = econtact.Relation,
                UserId = econtact.UserId,

            };
            
           await _unitOfWork.EmergencyContacts.AddAsync(contact);
            await _unitOfWork.SaveChangesAsync();
        }

        async Task IEmergencyContactsService.DeleteContact(int eid)
        {
            var econtact = await _unitOfWork.EmergencyContacts.GetByIdAsync(eid);
            if (econtact == null)
                return;

            _unitOfWork.EmergencyContacts.DeleteAsync(econtact);
            await _unitOfWork.SaveChangesAsync();
        
            
        }



        async Task<string> IEmergencyContactsService.UpdateContact(int  contactid, EmergencyContact updatedcontact , int userid)
        {
            var contact = await _unitOfWork.EmergencyContacts.GetByIdAsync(contactid);
            if (contact == null)
                return "This Contact Doesnot Exist";
            if (userid == contact.UserId)
            {
                contact.Id = updatedcontact.Id;
                contact.Name = updatedcontact.Name;
                contact.Phone = updatedcontact.Phone;
                contact.Relation = updatedcontact.Relation;


                 _unitOfWork.EmergencyContacts.UpdateAsync(contact);
                await _unitOfWork.SaveChangesAsync();
                return "Contact Updated Successfully";
            }
            return "This Contact Doesnot belong to this user , so Cannot be updated";
        }
    }
}
