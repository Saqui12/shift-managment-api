using Dominio.Entities.Identity;
using Dominio.Interfaces.Authentication;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Repositories.Authentication
{
    public class TokenMana(PeloterosDbContext _context,IConfiguration configuration) : ITokenMana
    {
        public async Task<int> AddRefreshToken(string userid, string refreshToken)
        {
             await _context.RefreshToken.AddAsync(new RefreshToken
            {
                UserId = userid,
                Token = refreshToken,
                //CreatedAt = DateTime.UtcNow,
                //ExpiresAt = DateTime.UtcNow.AddDays(7)
            });
            return await _context.SaveChangesAsync();
        }

        public string GenerateToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: cred
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string getRefreshToken()
        {

            const int byteSize = 64;
            byte[] randomNumber = new byte[byteSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
                return Convert.ToBase64String(randomNumber);
        }

        public List<Claim> GetUserClaimFromToken(string token)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenhandler.ReadJwtToken(token);
            if (jwtToken is null)
                return jwtToken.Claims.ToList();
            else
                return [];

        }

        public async Task<string> GetUserIdFromRefreshToken(string refreshtoken) 
            => (await _context.RefreshToken.FirstOrDefaultAsync(x => x.Token == refreshtoken))!.UserId;
        

        public async Task<int> UpdateRefreshToken(string userid, string refreshToken)
        {
            var user = await _context.RefreshToken.FirstOrDefaultAsync(x=>x.Token == refreshToken);
            if(user is null)
                return -1;
            user.Token = refreshToken;
            return await _context.SaveChangesAsync();

        }

        public async Task<bool> ValidateRefreshToken(string token)
        {
            var user = await _context.RefreshToken.FirstOrDefaultAsync(x => x.Token == token);
            return user != null;
        }
    }
}
