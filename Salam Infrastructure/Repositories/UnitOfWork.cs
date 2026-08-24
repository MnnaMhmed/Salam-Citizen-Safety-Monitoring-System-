using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

        private IGeneric_Repository<Plan> _plan;
        public IGeneric_Repository<Plan> Plan
        {
            get
            {
                if (_plan == null)
                    _plan = new Generic_Repository<Plan>(_context);

                return _plan;
            }
        }


        private IGeneric_Repository<Subscribtion> _subscribtions;
        public IGeneric_Repository<Subscribtion> Subscribtions
        {
            get
            {
                if (_subscribtions == null)
                    _subscribtions = new Generic_Repository<Subscribtion>(_context);

                return _subscribtions;
            }
        }

        private IGeneric_Repository<Notification> _notification;
        public IGeneric_Repository<Notification> Notifications
        {
            get
            {
                if (_notification == null)
                    _notification = new Generic_Repository<Notification>(_context);

                return _notification;
            }
        }

        private IGeneric_Repository<EmergencyContact> _emergencycontact;
        public IGeneric_Repository<EmergencyContact> EmergencyContacts
        {
            get
            {
                if (_emergencycontact == null)
                    _emergencycontact = new Generic_Repository<EmergencyContact>(_context);

                return _emergencycontact;
            }
        }


        private IGeneric_Repository<EmergencyNumber> _emergencynumber;
        public IGeneric_Repository<EmergencyNumber> EmergencyNumbers
        {
            get
            {
                if (_emergencynumber == null)
                    _emergencynumber = new Generic_Repository<EmergencyNumber>(_context);

                return _emergencynumber;
            }
        }

        private IGeneric_Repository<Support> _support;
        public IGeneric_Repository<Support> Supports
        {
            get
            {
                if (_support == null)
                    _support = new Generic_Repository<Support>(_context);

                return _support;
            }
        }

        private IGeneric_Repository<Rating> _rating;
        public IGeneric_Repository<Rating> Ratings
        {
            get
            {
                if (_rating == null)
                    _rating = new Generic_Repository<Rating>(_context);

                return _rating;
            }
        }


        private IGeneric_Repository<Payment> _payments;

        public IGeneric_Repository<Payment> Payments
        {
            get
            {
                if (_payments == null)
                    _payments = new Generic_Repository<Payment>(_context);

                return _payments;
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
    