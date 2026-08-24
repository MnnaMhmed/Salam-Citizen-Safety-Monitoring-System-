using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Domain.Entities;

namespace Salam_Application.DTOs
{
    public class EmergencyContactDto
    {

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Relation { get; set; }
    }
}
