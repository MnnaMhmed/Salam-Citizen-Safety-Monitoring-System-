using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;
namespace Salam_Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGeneric_Repository<User> Users { get; }
        IGeneric_Repository<Report> Reports { get; }
        IGeneric_Repository<Device> Devices { get; }
        IGeneric_Repository<Plan> Plan { get; }
        IGeneric_Repository<Subscribtion> Subscribtions { get; }
        IGeneric_Repository<Notification> Notifications { get; }
        IGeneric_Repository<EmergencyContact> EmergencyContacts { get; }
        IGeneric_Repository<EmergencyNumber> EmergencyNumbers { get; }
        Task<int> SaveChangesAsync();
    }
}