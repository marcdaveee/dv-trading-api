using Microsoft.AspNetCore.Identity;

namespace dv_trading_api.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(IdentityUser identityUser);
    }
}
