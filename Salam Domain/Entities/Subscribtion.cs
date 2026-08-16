using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Salam_Domain.Entities
{
    public class Subscribtion
    {
        public int id { get; set; }

public DateTime StartDate {  get; set; }
public DateTime EndDate { get; set; }
public bool IsActive { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Plan Plan { get; set; }
        public int PlanId { get; set; }


    }
}
