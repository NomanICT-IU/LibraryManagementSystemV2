namespace LibraryManagementSystemV2.BLL.Services;

public interface IPermissionService
{
    Task<IEnumerable<PermissionDto>> GetAllPermissionsAsync(int roleId, CancellationToken cancellationToken);
}

public class PermissionService(IPermissionRepository permissionRepository) : IPermissionService
{
    public async Task<IEnumerable<PermissionDto>> GetAllPermissionsAsync(int roleId, CancellationToken cancellationToken)
    {
        var result = await permissionRepository.GetAllPermissionsAsync(roleId, cancellationToken);
        return result.Adapt<IEnumerable<PermissionDto>>();
    }
}