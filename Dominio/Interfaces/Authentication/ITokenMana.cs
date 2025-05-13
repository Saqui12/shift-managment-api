using System.Security.Claims;

namespace Dominio.Interfaces.Authentication
{
    public interface ITokenMana
    {
        string getRefreshToken();
        string GenerateToken(List<Claim> claims);

        List<Claim> GetUserClaimFromToken(string token);
        Task<string> GetUserIdFromRefreshToken(string refreshtoken);

        Task<int> AddRefreshToken(string userid, string refreshToken);
        Task<int> UpdateRefreshToken(string userid, string refreshToken);
        Task<bool> ValidateRefreshToken(string token);
    }
}
