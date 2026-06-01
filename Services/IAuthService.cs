using HdiBackend.Models;
using HdiBackend.DTOs;

namespace HdiBackend.Services
{
    public interface IAuthService
    {
        Task<User?> Authenticate(string username, string password);
        Task<bool> RegisterAdjuster(RegisterAdjusterRequest request);
    }
}