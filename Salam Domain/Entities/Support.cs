using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salam_Domain.Entities
{
    public class Support
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
    }
}