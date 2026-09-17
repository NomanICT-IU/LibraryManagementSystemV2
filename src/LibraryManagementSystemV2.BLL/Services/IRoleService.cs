namespace LibraryManagementSystemV2.BLL.Services;

public interface IRoleService
{
    Task<bool> CreateRoleAsync(RoleDto roleDto, CancellationToken cancellationToken);

    Task<bool> UpdateRoleAsync(RoleDto roleDto, CancellationToken cancellationToken);

    Task<RoleDto?> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken);

    Task<bool> DeleteRoleAsync(int roleId, CancellationToken cancellationToken);
}

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    public async Task<bool> CreateRoleAsync(RoleDto roleDto, CancellationToken cancellationToken)
    {
        var role = roleDto.Adapt<Role>();

        return await roleRepository.CreateRoleAsync(
            role,
            cancellationToken);
    }

    public async Task<bool> UpdateRoleAsync(RoleDto roleDto, CancellationToken cancellationToken)
    {
        var role = roleDto.Adapt<Role>();

        return await roleRepository.UpdateRoleAsync(
            role,
            cancellationToken);
    }

    public async Task<RoleDto?> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetRoleByIdAsync(
            roleId,
            cancellationToken);

        return role?.Adapt<RoleDto>();
    }

    public Task<bool> DeleteRoleAsync(int roleId, CancellationToken cancellationToken)
    {
        return roleRepository.DeleteRoleAsync(
            roleId,
            cancellationToken);
    }
}