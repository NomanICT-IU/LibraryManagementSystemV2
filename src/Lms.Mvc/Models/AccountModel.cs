namespace Lms.Mvc.Models;


public sealed record LoginResponse(
    int UserId,
    string? AccessToken,
    string? RefreshToken,
    DateTime? AccessTokenExpiresOnUtc);