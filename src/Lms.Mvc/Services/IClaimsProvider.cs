using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Lms.Mvc.Services;

public interface IClaimsProvider
{
    ClaimsPrincipal CreatePrincipal(int userId, string email, string accessToken);
}

public sealed class ClaimsProvider : IClaimsProvider
{
    public ClaimsPrincipal CreatePrincipal(int userId, string email, string accessToken)
    {
        var claims = new List<Claim>
        { new(ClaimTypes.NameIdentifier, userId.ToString()) ,
          new(ClaimTypes.Email, email)
        };

        var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);

        AddRoles(jwtToken, claims);
        AddPermissions(jwtToken, claims);

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        return new ClaimsPrincipal(identity);
    }
    private static void AddRoles(JwtSecurityToken token, ICollection<Claim> claims)
    {
        foreach (var claim in token.Claims)
        {
            if (claim.Type is ClaimTypes.Role or "role" or "roles")
            {
                claims.Add(new Claim(ClaimTypes.Role, claim.Value));
            }
        }
    }
    private static void AddPermissions(JwtSecurityToken token, ICollection<Claim> claims)
    {
        foreach (var claim in token.Claims)
        {
            if (claim.Type is "permission" or "permissions")
            { claims.Add(new Claim("permission", claim.Value)); }
        }
    }
}