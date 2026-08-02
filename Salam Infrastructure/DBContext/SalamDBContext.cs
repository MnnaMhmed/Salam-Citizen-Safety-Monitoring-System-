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
         



    }
}
