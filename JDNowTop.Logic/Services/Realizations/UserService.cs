using JDNowTop.Data.Models;
using JDNowTop.Data.Repositories.Abstractions;
using JDNowTop.Logic.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JDNowTop.Logic.Services.Realizations
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserData, string> _userRepo;
        private readonly IConfiguration _configuration;

        public UserService(IRepository<UserData, string> userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }

        public async Task<JwtSecurityToken?> LogIn(string username, string password)
        {
            var dbUser = await _userRepo.GetIfAsync(u => u.UserName == username);
            if (dbUser == null) return null;

            var isPasswordCorrect = ValidatePassword(dbUser, password);
            if (!isPasswordCorrect) return null;

            var token = GenerateToken(dbUser);
            return token;
        }

        public async Task<bool> SignUp(string username, string password)
        {
            if (await _userRepo.GetIfAsync(u => u.UserName == username) != null) return false;

            CalculatePasswordHash(password, out string pHash, out string pSalt);

            var user = new UserData()
            {
                UserName = username,
                PasswordHash = pHash,
                PasswordSalt = pSalt,
                Role = "Default"
            };

            await _userRepo.CreateAsync(user);
            return true;
        }

        private bool ValidatePassword(UserData dbUser, string password)
        {
            byte[] hashKey = Convert.FromBase64String(dbUser.PasswordSalt);

            using (var hmac = new HMACSHA512(hashKey))
            {
                var hash = Convert.FromBase64String(dbUser.PasswordHash);
                var tryHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return hash.SequenceEqual(tryHash);
            }
        }

        private void CalculatePasswordHash(string password, out string pHash, out string pSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                pSalt = Convert.ToBase64String(hmac.Key);
                pHash = Convert.ToBase64String(
                    hmac.ComputeHash(Encoding.UTF8.GetBytes(password))
                    );
            }
        }

        private JwtSecurityToken GenerateToken(UserData user)
        {
            var claims = new List<Claim>() { new Claim(ClaimTypes.Role, user.Role) };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signingCredentials);

            return token;
        }
    }
}
