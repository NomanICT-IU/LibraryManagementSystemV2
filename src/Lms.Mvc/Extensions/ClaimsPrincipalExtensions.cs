using System.Security.Claims;

namespace Lms.Mvc.Extensions;


public static class ClaimsPrincipalExtensions
{
    public static bool HasPermission(
        this ClaimsPrincipal user,
        string permission)
    {
        return user.HasClaim(CustomClaimTypes.Permission, permission);
    }
}


