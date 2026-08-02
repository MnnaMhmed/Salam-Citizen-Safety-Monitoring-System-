using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salam_Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public string PhoneNumber { get; set; }
        public string BloodType { get; set; }
        public string AccountType { get; set; }
        public bool IsDeaf { get; set; }
        public string Password { get; set; }

        public ICollection<Report> Report { get; set; } = new List<Report>();
        public ICollection<Device> Devices { get; set; } = new List<Device>();
        public int NumOfReports { get; set; }
        public int NumOfDevices { get; set; }

    }
}
