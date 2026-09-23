using LibraryManagementSystemV2.Shared;

namespace LibraryManagementSystemV2.BLL.Services;

public interface IAuthService
{
    Task<LoginResult> LoginAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken);
}
public class AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtSigner jwtSigner, IRoleRepository roleRepository) : IAuthService
{
    public async Task<LoginResult> LoginAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken)
    {
        User user = await userRepository.GetUserByIndentityAsync(loginRequestDto.Identifier, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException("Invalid username or email address!");
        }
        if (!user.IsActive)
        {
            throw new InvalidException("Inactive account.");
        }

        if (!passwordHasher.Verify(RawPassword.Create(loginRequestDto.Password), PasswordHash.Create(PasswordHash.Argon2Id, user.PasswordHash)))
        {
            throw new InvalidException("Invalid password.");
        }
        var rolePermissions = await roleRepository.GetRollAndPermissionByUserId(user.UserId, cancellationToken);

        var accessToken = jwtSigner.SignAccessToken(AccessTokenSpec.Create(user.UserId, user.Email, rolePermissions.Roles, rolePermissions.Permissions, DateTime.UtcNow.AddHours(1)));

        var (RefreshToken, RefreshTokenHash) = jwtSigner.IssueRefreshToken();

        return new LoginResult(user.UserId, user.Email, accessToken, RefreshToken, DateTime.UtcNow.AddHours(1));

    }
}