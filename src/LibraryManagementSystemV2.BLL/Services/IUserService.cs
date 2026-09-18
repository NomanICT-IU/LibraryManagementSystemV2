namespace LibraryManagementSystemV2.BLL.Services;

public interface IUserService
{
    Task<bool> CreateUserAsync(UserDto userDto, CancellationToken cancellationToken);

    Task<bool> UpdateUserAsync(UserDto userDto, CancellationToken cancellationToken);

    Task<UserDto?> GetUserByIdAsync(int userId, CancellationToken cancellationToken);
    Task<UserDto?> GetUserByIndentityAsync(string indentity, CancellationToken cancellationToken);

    Task<bool> DeleteUserAsync(int userId, CancellationToken cancellationToken);
}

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<bool> CreateUserAsync(UserDto userDto, CancellationToken cancellationToken)
    {
        var user = userDto.Adapt<User>();

        return await userRepository.CreateUserAsync(user, cancellationToken);
    }

    public async Task<bool> UpdateUserAsync(UserDto userDto, CancellationToken cancellationToken)
    {
        var user = userDto.Adapt<User>();

        user.UpdateAT = DateTime.Now;

        return await userRepository.UpdateUserAsync(user, cancellationToken);
    }

    public async Task<UserDto?> GetUserByIdAsync(int userId, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByIdAsync(userId, cancellationToken);

        if (user == null)
        {
            return null;
        }

        return user.Adapt<UserDto>();
    }

    public async Task<bool> DeleteUserAsync(int userId, CancellationToken cancellationToken)
    {
        return await userRepository.DeleteUserAsync(userId, cancellationToken);
    }

    public async Task<UserDto> GetUserByIndentityAsync(string indentity, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByIndentityAsync(indentity, cancellationToken);

        return user.Adapt<UserDto>();
    }
}