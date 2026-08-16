using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs;
using Salam_Domain.Entities;

namespace Salam_Application.Services_Interfces
{
    public interface IReportService
    {

        public Task<bool> AddReport(ReportDto RDto, int id);
        public Task<List<Report>> GetUserReports(int id);
        public Task <List<Report>> GetAllReports();
        public Task UpdateStatus(string status, int repid);
        public Task DeleteReport(int repid);

    }
}
