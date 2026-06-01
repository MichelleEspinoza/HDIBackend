using HdiBackend.Data;
using HdiBackend.DTOs;
using HdiBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HdiBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Authenticate(string username, string password)
        {
            var usuario = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(password, usuario.Password))
            {
                return null;
            }

            return usuario;
        }

        public async Task<bool> RegisterAdjuster(RegisterAdjusterRequest request)
        {
            var exists = await _context.Users.AnyAsync(u => u.Username == request.Username);
            if (exists)
            {
                return false;
            }

            var newAdjuster = new User
            {
                Name = request.Name,
                Tel = request.Tel,
                Username = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                IdType = 2
            };

            _context.Users.Add(newAdjuster);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}