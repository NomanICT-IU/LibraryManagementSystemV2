namespace LibraryManagementSystemV2.DAL.Repository;

public interface IPermissionRepository
{
    Task<IEnumerable<Permission>> GetAllPermissionsAsync(int roleId, CancellationToken cancellationToken);
}

public class PermissionRepository(IDbConnection dbConnection) : IPermissionRepository
{
    public Task<IEnumerable<Permission>> GetAllPermissionsAsync(int roleId, CancellationToken cancellationToken)
    {
        var command = "Security.GetPermission";
        var paramters = new DynamicParameters();
        paramters.Add("@RoleId", roleId);

        return dbConnection.QueryAsync<Permission>(command, paramters, commandType: CommandType.StoredProcedure);
    }
}