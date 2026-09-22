namespace LibraryManagementSystemV2.BLL.Dtos;

//public class LoginResponseDto
//{
//    public int UserId { get; set; }
//    public string UserName { get; set; } = string.Empty;
//    public string Email { get; set; } = string.Empty;
//    public int RoleId { get; set; }
//    public string RoleName { get; set; } = string.Empty;
//    public string Token { get; set; } = string.Empty;
//}
public sealed record LoginResult(
    int UserId,
    string? AccessToken,
    string? RefreshToken,
    DateTime? AccessTokenExpiresOnUtc);