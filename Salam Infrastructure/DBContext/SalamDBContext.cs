using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Domain.Entities;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace Salam_Infrastructure.DBContext
{
    public class SalamDBContext : DbContext
    {
        public SalamDBContext(DbContextOptions<SalamDBContext> option):base (option)
        {
            
        }
        public DbSet <User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Subscribtion> Subscribtions { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<EmergencyNumber> EmergencyNumbers { get; set; }
        public DbSet<Support> Supports { get; set; }



    }
}
