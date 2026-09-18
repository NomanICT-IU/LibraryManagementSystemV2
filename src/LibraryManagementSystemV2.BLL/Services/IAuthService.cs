using LibraryManagementSystemV2.Shared;

namespace LibraryManagementSystemV2.BLL.Services;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken);
}
public class AuthService(IUserRepository userRepository) : IAuthService
{
    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken)
    {
        User user = await userRepository.GetUserByIndentityAsync(loginRequestDto.Identity, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException("Invalid username or email address!");
        }
        if (!user.IsActive)
        {
            throw new InvalidException("Inactive account.");
        }

        return new LoginResponseDto()
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Email = user.Email,
        };

    }
}