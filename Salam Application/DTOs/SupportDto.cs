using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Salam_Application.DTOs.Support
{
    public class SupportDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}