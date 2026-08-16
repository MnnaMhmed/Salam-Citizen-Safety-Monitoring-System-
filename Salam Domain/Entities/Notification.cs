using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salam_Domain.Entities
{
    public class Notification
    {


        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }


    }
}
