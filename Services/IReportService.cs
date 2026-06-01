using HdiBackend.Models;
using HdiBackend.DTOs;

namespace HdiBackend.Services
{
    public interface IReportService
    {
        Task<Report?> GetById(int id);
        Task<IEnumerable<Report>> GetByFilters(int idOffice, string policyNumber);
        Task<Report> Create(CreateReportRequest request);
    }
}