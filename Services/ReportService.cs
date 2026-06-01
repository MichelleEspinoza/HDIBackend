using HdiBackend.Data;
using HdiBackend.DTOs;
using HdiBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HdiBackend.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context) => _context = context;

        public async Task<Report?> GetById(int id) =>
            await _context.Reports.Include(r => r.Adjuster).FirstOrDefaultAsync(r => r.IdReport == id);

        public async Task<IEnumerable<Report>> GetByFilters(int idOffice, string policyNumber) =>
            await _context.Reports.Where(r => r.IdOffice == idOffice && r.PolicyNumber == policyNumber).ToListAsync();

        public async Task<Report> Create(CreateReportRequest request)
        {
            var dateTime = request.DateTime ?? DateTime.Now;
            dateTime = dateTime.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(dateTime, DateTimeKind.Utc) : dateTime.ToUniversalTime();

            var newReport = new Report
            {
                IdOffice = request.IdOffice ?? 1,
                PolicyNumber = request.PolicyNumber ?? "",
                DateTime = dateTime,
                Location = request.Location ?? "",
                ReporterName = request.ReporterName ?? "Sin Información",
                ReporterPhone = request.ReporterPhone ?? "",
                Email = request.Email ?? "",
                Description = request.Description ?? "",
                LicensePlate = request.LicensePlate ?? "",
                Color = request.Color ?? "",
                Notes = request.Notes,
                IdUser = request.IdUser
            };

            _context.Reports.Add(newReport);
            await _context.SaveChangesAsync();
            return newReport;
        }
    }
}