using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salam_Domain.Entities
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int DurationInDays { get; set; }
        public ICollection<Subscribtion> Subscribes { get; set; } = new List<Subscribtion>();

    }
}
