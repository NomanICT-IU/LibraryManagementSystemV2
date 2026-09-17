namespace LibraryManagementSystemV2.DAL.Repository;

public interface IUserRepository
{
    Task<bool> CreateUserAsync(User user, CancellationToken cancellationToken);
    Task<bool> UpdateUserAsync(User user, CancellationToken cancellationToken);
    Task<User?> GetUserByIdAsync(int userId, CancellationToken cancellationToken);
    Task<bool> DeleteUserAsync(int userId, CancellationToken cancellationToken);
}
public class UserRepository(IDbConnection dbConnection) : IUserRepository
{
    public async Task<bool> CreateUserAsync(User user, CancellationToken cancellationToken)
    {
        var command = "Security.CreateUser";
        var parameters = new DynamicParameters();
        parameters.Add("@UserName", user.UserName);
        parameters.Add("@Email", user.Email);
        parameters.Add("@PasswordHash", user.PasswordHash);
        parameters.Add("@FullName", user.FullName);
        parameters.Add("@IsActive", user.IsActive);
        parameters.Add("@CreatedAt", user.CreatedAt);
        var result = await dbConnection.ExecuteAsync(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<bool> DeleteUserAsync(int userId, CancellationToken cancellationToken)
    {
        var command = "Security.DeleteUser";

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId);

        var result = await dbConnection.ExecuteAsync(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public async Task<User> GetUserByIdAsync(int userId, CancellationToken cancellationToken)
    {
        var command = "Security.GetUserById";

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId);

        var commandDefinition = new CommandDefinition(
            commandText: command,
            parameters: parameters,
            commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken);

        var result = await dbConnection.QuerySingleOrDefaultAsync<User>(
            commandDefinition);

        return result;
    }

    public async Task<bool> UpdateUserAsync(User user, CancellationToken cancellationToken)
    {
        var command = "Security.UpdateUser";
        var parameters = new DynamicParameters();
        parameters.Add("@UserId", user.UserId);
        parameters.Add("@UserName", user.UserName);
        parameters.Add("@Email", user.Email);
        parameters.Add("@PasswordHash", user.PasswordHash);
        parameters.Add("@FullName", user.FullName);
        parameters.Add("@IsActive", user.IsActive);
        var result = await dbConnection.ExecuteAsync(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);
        return result > 0;
    }
}