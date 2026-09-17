namespace LibraryManagementSystemV2.DAL.Repository;

public interface IRoleRepository
{
    Task<bool> CreateRoleAsync(Role role, CancellationToken cancellationToken);

    Task<bool> UpdateRoleAsync(Role role, CancellationToken cancellationToken);

    Task<Role?> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken);

    Task<bool> DeleteRoleAsync(int roleId, CancellationToken cancellationToken);
}

public class RoleRepository(IDbConnection dbConnection) : IRoleRepository
{
    public async Task<bool> CreateRoleAsync(Role role, CancellationToken cancellationToken)
    {
        var command = "Security.CreateRoles";

        var parameters = new DynamicParameters();

        parameters.Add("@RoleName", role.RoleName);
        parameters.Add("@RoleCode", role.RoleCode);
        parameters.Add("@Description", role.Description);
        parameters.Add("@IsActive", role.IsActive);
        parameters.Add("@CreatedAt", role.CreatedAt);

        var result = await dbConnection.ExecuteAsync(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public async Task<bool> UpdateRoleAsync(Role role, CancellationToken cancellationToken)
    {
        var command = "Security.UpdateRole";

        var parameters = new DynamicParameters();

        parameters.Add("@RoleId", role.RoleId);
        parameters.Add("@RoleName", role.RoleName);
        parameters.Add("@RoleCode", role.RoleCode);
        parameters.Add("@Description", role.Description);
        parameters.Add("@IsActive", role.IsActive);
        parameters.Add("@UpdatedAt", role.UpdatedAt);

        var result = await dbConnection.ExecuteAsync(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public async Task<Role?> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken)
    {
        var command = "Security.GetRoleById";

        var parameters = new DynamicParameters();

        parameters.Add("@RoleId", roleId);

        var result = await dbConnection.QueryFirstOrDefaultAsync<Role>(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);

        return result;
    }

    public async Task<bool> DeleteRoleAsync(int roleId, CancellationToken cancellationToken)
    {
        var command = "Security.DeleteRole";

        var parameters = new DynamicParameters();

        parameters.Add("@RoleId", roleId);

        var result = await dbConnection.ExecuteAsync(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);

        return result > 0;
    }
}