using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace LibraryManagementSystemV2.Api.Authentication;

public sealed class JwtBearerOptionsConfiguration(IJwtSigner jwtSigner)
    : IConfigureNamedOptions<JwtBearerOptions>
{
    public void Configure(JwtBearerOptions options) =>
        Configure(JwtBearerDefaults.AuthenticationScheme, options);

    public void Configure(string? name, JwtBearerOptions options)
    {
        if (name != JwtBearerDefaults.AuthenticationScheme)
        {
            return;
        }

        options.MapInboundClaims = false;
        var validationParameters = jwtSigner.GetTokenValidationParameters();
        validationParameters.RoleClaimType = ClaimTypes.Role;
        options.TokenValidationParameters = validationParameters;
    }
}

public static class AuthenticationDependencyInjection
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddSingleton<IConfigureOptions<JwtBearerOptions>, JwtBearerOptionsConfiguration>();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        return services;
    }
}
