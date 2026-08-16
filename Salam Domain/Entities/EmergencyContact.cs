using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salam_Domain.Entities
{
    public class EmergencyContact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Relation { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
