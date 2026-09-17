namespace LibraryManagementSystemV2.BLL.Services;

public interface IRoleService
{
    Task<bool> CreateRoleAsync(RoleDto roleDto, CancellationToken cancellationToken);

    Task<bool> UpdateRoleAsync(RoleDto roleDto, CancellationToken cancellationToken);

    Task<RoleDto?> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken);

    Task<bool> DeleteRoleAsync(int roleId, CancellationToken cancellationToken);
    Task<bool> CreateUserRoleAsync(UserRoleDto userRoleDto, CancellationToken cancellationToken);

    Task<bool> UpdateUserRoleAsync(UserRoleDto userRoleDto, CancellationToken cancellationToken);

    Task<UserRoleDto?> GetUserRoleByIdAsync(int userRoleId, CancellationToken cancellationToken);

    Task<bool> DeleteUserRoleAsync(int userRoleId, CancellationToken cancellationToken);
    Task<bool> CreateRolePermissionAsync(RolePermissionDto rolePermissionDto, CancellationToken cancellationToken);

    Task<bool> UpdateRolePermissionAsync(RolePermissionDto rolePermissionDto, CancellationToken cancellationToken);

    Task<RolePermissionDto?> GetRolePermissionByIdAsync(int rolePermissionId, CancellationToken cancellationToken);

    Task<bool> DeleteRolePermissionAsync(int rolePermissionId, CancellationToken cancellationToken);

}

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    public async Task<bool> CreateRoleAsync(RoleDto roleDto, CancellationToken cancellationToken)
    {
        var role = roleDto.Adapt<Role>();

        return await roleRepository.CreateRoleAsync(role, cancellationToken);
    }

    public async Task<bool> UpdateRoleAsync(RoleDto roleDto, CancellationToken cancellationToken)
    {
        var role = roleDto.Adapt<Role>();

        return await roleRepository.UpdateRoleAsync(role, cancellationToken);
    }

    public async Task<RoleDto?> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetRoleByIdAsync(roleId, cancellationToken);

        return role?.Adapt<RoleDto>();
    }

    public Task<bool> DeleteRoleAsync(int roleId, CancellationToken cancellationToken)
    {
        return roleRepository.DeleteRoleAsync(roleId, cancellationToken);
    }

    public Task<bool> CreateUserRoleAsync(UserRoleDto userRoleDto, CancellationToken cancellationToken)
    {
        return roleRepository.CreateUserRoleAsync(userRoleDto.Adapt<UserRole>(), cancellationToken);
    }

    public Task<bool> UpdateUserRoleAsync(UserRoleDto userRoleDto, CancellationToken cancellationToken)
    {
        return roleRepository.UpdateUserRoleAsync(userRoleDto.Adapt<UserRole>(), cancellationToken);
    }

    public async Task<UserRoleDto> GetUserRoleByIdAsync(int userRoleId, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetUserRoleByIdAsync(userRoleId, cancellationToken);

        return role?.Adapt<UserRoleDto>();
    }

    public async Task<bool> DeleteUserRoleAsync(int userRoleId, CancellationToken cancellationToken)
    {
        return await roleRepository.DeleteUserRoleAsync(userRoleId, cancellationToken);
    }

    public async Task<bool> CreateRolePermissionAsync(RolePermissionDto rolePermissionDto, CancellationToken cancellationToken)
    {
        return await roleRepository.CreateRolePermissionAsync(rolePermissionDto.Adapt<RolePermission>(), cancellationToken);
    }

    public async Task<bool> UpdateRolePermissionAsync(RolePermissionDto rolePermissionDto, CancellationToken cancellationToken)
    {
        return await roleRepository.UpdateRolePermissionAsync(rolePermissionDto.Adapt<RolePermission>(), cancellationToken);
    }

    public async Task<RolePermissionDto?> GetRolePermissionByIdAsync(int rolePermissionId, CancellationToken cancellationToken)
    {
        var rolePermission = await roleRepository.GetRolePermissionByIdAsync(rolePermissionId, cancellationToken);
        return rolePermission?.Adapt<RolePermissionDto>();
    }

    public async Task<bool> DeleteRolePermissionAsync(int rolePermissionId, CancellationToken cancellationToken)
    {
        return await roleRepository.DeleteRolePermissionAsync(rolePermissionId, cancellationToken);
    }
}