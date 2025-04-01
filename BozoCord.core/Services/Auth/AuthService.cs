using System;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BozoCord.Core.Models.User;
using BozoCord.Core.Services.Data;
using BC = BCrypt.Net.BCrypt;

namespace BozoCord.Core.Services.Auth
{
    public interface IAuthService
    {
        Task<(bool success, string token)> AuthenticateAsync(string email, string password);
        Task<(bool success, User user)> RegisterAsync(string username, string email, string password);
        string GenerateJwtToken(User user);
        Task<User?> GetUserByIdAsync(Guid userId);
    }

    public class AuthService : IAuthService
    {
        private readonly BozoCordDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(BozoCordDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<(bool success, string token)> AuthenticateAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return (false, string.Empty);

            if (!BC.Verify(password, user.PasswordHash))
                return (false, string.Empty);

            var token = GenerateJwtToken(user);
            return (true, token);
        }

        public async Task<(bool success, User user)> RegisterAsync(string username, string email, string password)
        {
            if (await _context.Users.AnyAsync(u => u.Email == email))
                return (false, null);

            if (await _context.Users.AnyAsync(u => u.Username == username))
                return (false, null);

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = BC.HashPassword(password),
                CreatedAt = DateTime.UtcNow,
                LastSeen = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return (true, user);
        }

        public string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }
    }
} 