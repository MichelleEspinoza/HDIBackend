using HdiBackend.Data;
using HdiBackend.DTOs;
using HdiBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HdiBackend.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly ApplicationDbContext _context;

        public PolicyService(ApplicationDbContext context) => _context = context;

        public async Task<List<Policy>> SearchPolicies(int? idOffice, string? policyNumber)
        {
            var query = _context.Policies.AsQueryable();
            if (idOffice.HasValue) query = query.Where(p => p.IdOffice == idOffice.Value);
            if (!string.IsNullOrEmpty(policyNumber)) query = query.Where(p => p.PolicyNumber == policyNumber);

            return await query.ToListAsync();
        }

        public async Task<bool> CreatePolicy(CreatePolicyRequest request)
        {
            var newPolicy = new Policy
            {
                PolicyNumber = request.PolicyNumber ?? "S/N",
                PolicyHolder = request.PolicyHolder ?? "Sin Nombre",
                Beneficiary = request.Beneficiary ?? "Sin Beneficiario",
                PaymentFrequency = request.PaymentFrequency ?? "Mensual",
                VehicleInfo = request.VehicleInfo ?? "Sin Información",
                LineOfBusiness = request.LineOfBusiness ?? "General",
                IsPaid = request.IsPaid ?? false,
                IdOffice = request.IdOffice,
                StartDate = ParseDate(request.StartDate, DateTime.UtcNow),
                EndDate = ParseDate(request.EndDate, DateTime.UtcNow.AddYears(1)),
                IssueDate = ParseDate(request.IssueDate, DateTime.UtcNow)
            };

            _context.Policies.Add(newPolicy);
            return await _context.SaveChangesAsync() > 0;
        }

        private DateTime ParseDate(string? dateStr, DateTime defaultDate) =>
            DateTime.TryParse(dateStr, out var d) ? DateTime.SpecifyKind(d, DateTimeKind.Utc) : DateTime.SpecifyKind(defaultDate, DateTimeKind.Utc);
    }
}