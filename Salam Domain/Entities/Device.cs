using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salam_Domain.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string SerialNumber { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
    
}
