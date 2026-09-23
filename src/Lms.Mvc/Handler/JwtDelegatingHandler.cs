using Lms.Mvc.Services;
using System.Net.Http.Headers;

namespace Lms.Mvc.Handler;

public class JwtDelegatingHandler(
    IHttpContextAccessor httpContextAccessor) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = httpContextAccessor
            .HttpContext?
            .Request
            .Cookies[TokenCookieService.AccessTokenCookie];

        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
