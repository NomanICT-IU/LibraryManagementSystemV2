namespace LibraryManagementSystemV2.DAL.Repository;

public interface IRoleRepository
{
    Task<bool> CreateRoleAsync(Role role, CancellationToken cancellationToken);

    Task<bool> UpdateRoleAsync(Role role, CancellationToken cancellationToken);

    Task<Role?> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken);

    Task<bool> DeleteRoleAsync(int roleId, CancellationToken cancellationToken);

    Task<bool> CreateUserRoleAsync(UserRole userRole, CancellationToken cancellationToken);

    Task<bool> UpdateUserRoleAsync(UserRole userRole, CancellationToken cancellationToken);

    Task<UserRole?> GetUserRoleByIdAsync(int userRoleId, CancellationToken cancellationToken);

    Task<bool> DeleteUserRoleAsync(int userRoleId, CancellationToken cancellationToken);

    Task<bool> CreateRolePermissionAsync(RolePermission rolePermission, CancellationToken cancellationToken);

    Task<bool> UpdateRolePermissionAsync(RolePermission rolePermission, CancellationToken cancellationToken);

    Task<RolePermission?> GetRolePermissionByIdAsync(int rolePermissionId, CancellationToken cancellationToken);

    Task<bool> DeleteRolePermissionAsync(int rolePermissionId, CancellationToken cancellationToken);

    Task<RolesPermissions> GetRollAndPermissionByUserId(int userId, CancellationToken cancellationToken);

}
public class RoleRepository(IDbConnection dbConnection) : IRoleRepository
{
    public async Task<bool> CreateRoleAsync(Role role, CancellationToken cancellationToken)
    {
        var command = "Security.CreateRole";

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

    public async Task<bool> CreateUserRoleAsync(UserRole userRole, CancellationToken cancellationToken)
    {
        var command = "Security.CreateUserRole";
        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userRole.UserId);
        parameters.Add("@RoleId", userRole.RoleId);
        parameters.Add("@AssignedAt", userRole.AssignedAt);
        var result = await dbConnection.ExecuteAsync(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<bool> UpdateUserRoleAsync(UserRole userRole, CancellationToken cancellationToken)
    {
        var command = "Security.UpdateUserRole";
        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userRole.UserId);
        parameters.Add("@RoleId", userRole.RoleId);
        parameters.Add("@AssignedAt", userRole.AssignedAt);
        var result = await dbConnection.ExecuteAsync(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<UserRole> GetUserRoleByIdAsync(int userRoleId, CancellationToken cancellationToken)
    {
        var command = "Security.GetUserRoleById";
        var parameters = new DynamicParameters();
        parameters.Add("@UserRoleId", userRoleId);
        var result = await dbConnection.QueryFirstOrDefaultAsync<UserRole>(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<bool> DeleteUserRoleAsync(int userRoleId, CancellationToken cancellationToken)
    {
        var command = "Security.DeleteUserRole";
        var parameters = new DynamicParameters();
        parameters.Add("@UserRoleId", userRoleId);
        var result = await dbConnection.ExecuteAsync(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<bool> CreateRolePermissionAsync(RolePermission rolePermission, CancellationToken cancellationToken)
    {
        var command = "Security.CreateRolePermission";
        var parameters = new DynamicParameters();
        parameters.Add("@RoleId", rolePermission.RoleId);
        parameters.Add("@PermissionId", rolePermission.PermissionId);
        parameters.Add("@AssignedAt", rolePermission.AssignedAt);
        var result = await dbConnection.ExecuteAsync(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<bool> UpdateRolePermissionAsync(RolePermission rolePermission, CancellationToken cancellationToken)
    {
        var command = "Security.UpdateRolePermission";
        var parameters = new DynamicParameters();
        parameters.Add("@RolePermissionId", rolePermission.RolePermissionId);
        parameters.Add("@RoleId", rolePermission.RoleId);
        parameters.Add("@PermissionId", rolePermission.PermissionId);
        parameters.Add("@AssignedAt", rolePermission.AssignedAt);
        var result = await dbConnection.ExecuteAsync(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<RolePermission> GetRolePermissionByIdAsync(int rolePermissionId, CancellationToken cancellationToken)
    {
        var command = "Security.GetRolePermissionById";
        var parameters = new DynamicParameters();
        parameters.Add("@RolePermissionId", rolePermissionId);
        var result = await dbConnection.QueryFirstOrDefaultAsync<RolePermission>(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<bool> DeleteRolePermissionAsync(int rolePermissionId, CancellationToken cancellationToken)
    {
        var command = "Security.DeleteRolePermission";
        var parameters = new DynamicParameters();
        parameters.Add("@RolePermissionId", rolePermissionId);
        var result = await dbConnection.ExecuteAsync(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<RolesPermissions> GetRollAndPermissionByUserId(int userId, CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId);

        var command = new CommandDefinition("Security.GetUserRolesAndPermissions",
        parameters,
        commandType: CommandType.StoredProcedure);
        using var result = await dbConnection.QueryMultipleAsync(command);

        var roles = (await result.ReadAsync<string>()).ToList();
        var permissions = (await result.ReadAsync<string>()).ToList();

        return new RolesPermissions
        {
            Roles = roles,
            Permissions = permissions
        };
    }
}