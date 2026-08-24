using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salam_Application.DTOs.Profile
{
    public class ProfileDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string NationalId { get; set; }

        public string PhoneNumber { get; set; }

        public string BloodType { get; set; }

        public string AccountType { get; set; }

        public bool IsDeaf { get; set; }
    }
}
