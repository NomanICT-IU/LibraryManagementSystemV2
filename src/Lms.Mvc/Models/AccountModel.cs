namespace Lms.Mvc.Models;


public sealed record LoginResponse(
    int UserId,
    string Email,
    string? AccessToken,
    string? RefreshToken,
    DateTime? AccessTokenExpiresOnUtc);