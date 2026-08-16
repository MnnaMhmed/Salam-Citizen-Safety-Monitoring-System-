using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Salam_Application.DTOs;
using Salam_Application.Services_Interfces;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;

namespace Salam_Application.Services
{
    public class ReportService : IReportService
    {


        private readonly IUnitOfWork _unitOfWork;
        public ReportService( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        async Task<bool> IReportService.AddReport(ReportDto RDto, int id)
        {

            var reporttype = RDto.Type;

            var  isPremiumReport = reporttype == "مرئي" || reporttype == "سماعي";

            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
                return false;


            if ( isPremiumReport && user.AccountType != "Premium")
                return false;
            var report = new Report
            {
                Type = RDto.Type,
                Description = RDto.Description,
                Location = RDto.Location,
                CreatedAt = DateTime.Now,
                UserId = id
            };


            await _unitOfWork.Reports.AddAsync(report);
            await _unitOfWork.SaveChangesAsync();
            return true;


        }


        async Task<List<Report>> IReportService.GetAllReports()
        {
            var reports = await _unitOfWork.Reports.GetAllAsync();
            return reports.ToList();
        }

        async Task<List<Report>> IReportService.GetUserReports(int id)
        {


            var reports = await _unitOfWork.Reports.GetAllAsync();
            return reports.Where(a => a.UserId == id).ToList();

        }

        async Task IReportService.UpdateStatus(string status , int repid)
        {
          var rep=  await _unitOfWork.Reports.GetByIdAsync(repid);
            if (rep == null)
                throw new Exception("Report not found");
            if (status == "Resolved")
            
                rep.IsResolved = true;
            
            else
            
                rep.IsResolved = false;
                await _unitOfWork.SaveChangesAsync();
            

        }

        async Task IReportService.DeleteReport(int repid)
        {
            var rep = await _unitOfWork.Reports.GetByIdAsync(repid);

            if (rep == null)
                throw new Exception("Report not found");

            _unitOfWork.Reports.DeleteAsync(rep);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
