namespace Lms.Mvc.Services;

public interface ITokenCookieService
{
    void AddTokens(
        string accessToken,
        DateTime? accessTokenExpiresOnUtc,
        string refreshToken);

    void RemoveTokens();
}
public class TokenCookieService(
    IHttpContextAccessor httpContextAccessor) : ITokenCookieService
{
    private const string AccessTokenCookie = "access_token";
    private const string RefreshTokenCookie = "refresh_token";

    public void AddTokens(
        string accessToken,
        DateTime? accessTokenExpiresOnUtc,
        string refreshToken)
    {
        var response = httpContextAccessor.HttpContext?.Response
            ?? throw new InvalidOperationException("HttpContext is not available.");

        response.Cookies.Append(
            AccessTokenCookie,
            accessToken,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = accessTokenExpiresOnUtc,
                IsEssential = true,
                Path = "/"
            });

        response.Cookies.Append(
            RefreshTokenCookie,
            refreshToken,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                IsEssential = true,
                Path = "/"
            });
    }

    public void RemoveTokens()
    {
        var response = httpContextAccessor.HttpContext?.Response
            ?? throw new InvalidOperationException("HttpContext is not available.");

        response.Cookies.Delete(AccessTokenCookie);
        response.Cookies.Delete(RefreshTokenCookie);
    }
}