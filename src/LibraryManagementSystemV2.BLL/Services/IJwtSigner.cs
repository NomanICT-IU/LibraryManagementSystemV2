using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace LibraryManagementSystemV2.BLL.Services;

public interface IJwtSigner
{
    string SignAccessToken(AccessTokenSpec spec);

    (string RefreshToken, string RefreshTokenHash) IssueRefreshToken();

    /// <summary>Signature + expiry only — the revocation-list check is a separate, repository-backed step (§9.3 <c>TokenValidationApi</c>).</summary>
    bool ValidateSignature(string token);

    string HashRefreshToken(string refreshToken);
    TokenValidationParameters GetTokenValidationParameters();
}
public sealed class AccessTokenSpec
{
    private AccessTokenSpec(
        int subject,
        string email,
        IReadOnlyList<string> roles,
        IReadOnlyList<string> permissions,
        DateTime expiresOnUtc)
    {
        Subject = subject;
        Email = email;
        Roles = roles;
        Permissions = permissions;
        ExpiresOnUtc = expiresOnUtc;
    }

    public int Subject { get; }
    public string Email { get; }

    public IReadOnlyList<string> Roles { get; }

    public IReadOnlyList<string> Permissions { get; }

    public DateTime ExpiresOnUtc { get; }

    public static AccessTokenSpec Create(
        int subject,
        string email,
        IReadOnlyList<string> roles,
        IReadOnlyList<string> permissions,
        DateTime expiresOnUtc)
    {
        if (subject == 0)
            throw new ArgumentException("Subject is required.", nameof(subject));

        ArgumentNullException.ThrowIfNull(roles);
        ArgumentNullException.ThrowIfNull(permissions);

        if (expiresOnUtc <= DateTime.UtcNow)
            throw new ArgumentException(
                "Token expiration time must be in the future.",
                nameof(expiresOnUtc));

        return new AccessTokenSpec(
            subject,
            email,
            roles,
            permissions,
            expiresOnUtc);
    }


}


public sealed class RsaJwtSigner : IJwtSigner, IDisposable
{
    private const string PermissionClaimType = "permission";
    private const string SessionIdClaimType = "sid";

    private readonly RSA _rsa;
    private readonly SigningCredentials _signingCredentials;
    private readonly TokenValidationParameters _validationParameters;
    private readonly JwtSecurityTokenHandler _handler = new();

    public RsaJwtSigner()
    {
        _rsa = RSA.Create(2048);
        var key = new RsaSecurityKey(_rsa);
        _signingCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256);
        _validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ClockSkew = TimeSpan.FromSeconds(30),
        };
    }

    public string SignAccessToken(AccessTokenSpec spec)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, spec.Subject.ToString()),
            new(JwtRegisteredClaimNames.Email, spec.Email),
        };

        claims.AddRange(spec.Roles.Select(r => new Claim(ClaimTypes.Role, r)));
        claims.AddRange(spec.Permissions.Select(p => new Claim(PermissionClaimType, p)));

        var token = new JwtSecurityToken(
            claims: claims,
            expires: spec.ExpiresOnUtc,
            signingCredentials: _signingCredentials);

        return _handler.WriteToken(token);
    }

    public (string RefreshToken, string RefreshTokenHash) IssueRefreshToken()
    {
        var raw = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

        return (raw, HashRefreshToken(raw));
    }

    public bool ValidateSignature(string token)
    {
        try
        {
            _handler.ValidateToken(token, _validationParameters, out _);
            return true;
        }
        catch (Exception ex) when (ex is SecurityTokenException or ArgumentException)
        {
            return false;
        }
    }

    public string HashRefreshToken(string refreshToken) =>
        Convert.ToHexString(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(refreshToken)));


    public TokenValidationParameters GetTokenValidationParameters() => _validationParameters;

    public void Dispose() => _rsa.Dispose();
}
