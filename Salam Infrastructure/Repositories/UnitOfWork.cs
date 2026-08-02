using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;
using Salam_Infrastructure.DBContext;
namespace Salam_Infrastructure.Repositories
{


    public class UnitOfWork : IUnitOfWork
    {
        private readonly SalamDBContext _context;

        public UnitOfWork(SalamDBContext context)
        {
            _context = context;
        }

        private IGeneric_Repository<User> _users;
        public IGeneric_Repository<User> Users
        {
            get
            {
                if (_users == null)
                    _users = new Generic_Repository<User>(_context);

                return _users;
            }
        }

        private IGeneric_Repository<Report> _reports;
        public IGeneric_Repository<Report> Reports
        {
            get
            {
                if (_reports == null)
                    _reports = new Generic_Repository<Report>(_context);

                return _reports;
            }
        }

        private IGeneric_Repository<Device> _devices;
        public IGeneric_Repository<Device> Devices
        {
            get
            {
                if (_devices == null)
                    _devices = new Generic_Repository<Device>(_context);

                return _devices;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
    