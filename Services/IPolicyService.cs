using HdiBackend.Models;
using HdiBackend.DTOs;

namespace HdiBackend.Services
{
    public interface IPolicyService
    {
        Task<List<Policy>> SearchPolicies(int? idOffice, string? policyNumber);
        Task<bool> CreatePolicy(CreatePolicyRequest request);
    }
}