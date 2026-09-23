using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RolesController(IRoleService roleService) : ControllerBase
{
    // CREATE
    [HttpPost("create-role")]
    public async Task<IActionResult> CreateRole([FromBody] RoleDto roleDto, CancellationToken cancellationToken)
    {
        var result = await roleService.CreateRoleAsync(roleDto, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = result
        });
    }


    // UPDATE
    [HttpPut("update-role")]
    public async Task<IActionResult> UpdateRole([FromBody] RoleDto roleDto, CancellationToken cancellationToken)
    {
        var result = await roleService.UpdateRoleAsync(roleDto, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = result
        });
    }


    // GET BY ID
    [HttpGet("get-role-by-id/{roleId:int}")]
    public async Task<IActionResult> GetRoleById(int roleId, CancellationToken cancellationToken)
    {
        var result = await roleService.GetRoleByIdAsync(roleId, cancellationToken);

        return Ok(new ApiResponse<RoleDto>
        {
            Data = result
        });
    }


    // DELETE
    [HttpDelete("delete-role/{roleId:int}")]
    public async Task<IActionResult> DeleteRole(int roleId, CancellationToken cancellationToken)
    {
        var result = await roleService.DeleteRoleAsync(roleId, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = result
        });
    }

    // CREATE
    [HttpPost("create-user-role")]
    public async Task<IActionResult> CreateUserRole([FromBody] UserRoleDto userRoleDto, CancellationToken cancellationToken)
    {
        var result = await roleService.CreateUserRoleAsync(userRoleDto, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = result
        });
    }


    // UPDATE
    [HttpPut("update-user-role")]
    public async Task<IActionResult> UpdateUserRole([FromBody] UserRoleDto userRoleDto, CancellationToken cancellationToken)
    {
        var result = await roleService.UpdateUserRoleAsync(userRoleDto, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = result
        });
    }


    // GET BY ID
    [HttpGet("get-user-role-by-id/{userRoleId:int}")]
    public async Task<IActionResult> GetUserRoleById(int userRoleId, CancellationToken cancellationToken)
    {
        var result = await roleService.GetUserRoleByIdAsync(userRoleId, cancellationToken);

        return Ok(new ApiResponse<UserRoleDto>
        {
            Data = result
        });
    }


    // DELETE
    [HttpDelete("delete-user-role/{userRoleId:int}")]
    public async Task<IActionResult> DeleteUserRole(int userRoleId, CancellationToken cancellationToken)
    {
        var result = await roleService.DeleteUserRoleAsync(userRoleId, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = result
        });
    }


    // CREATE
    [HttpPost("create-role-permission")]
    public async Task<IActionResult> CreateRolePermission([FromBody] RolePermissionDto rolePermissionDto, CancellationToken cancellationToken)
    {
        var result = await roleService.CreateRolePermissionAsync(rolePermissionDto, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = result
        });
    }


    // UPDATE
    [HttpPut("update-role-permission")]
    public async Task<IActionResult> UpdateUserPermission([FromBody] RolePermissionDto rolePermissionDto, CancellationToken cancellationToken)
    {
        var result = await roleService.UpdateRolePermissionAsync(rolePermissionDto, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = result
        });
    }


    // GET BY ID
    [HttpGet("get-role-permission-by-id/{rolePermissionId:int}")]
    public async Task<IActionResult> GetUserPermissionById(int rolePermissionId, CancellationToken cancellationToken)
    {
        var result = await roleService.GetRolePermissionByIdAsync(rolePermissionId, cancellationToken);

        return Ok(new ApiResponse<RolePermissionDto>
        {
            Data = result
        });
    }


    // DELETE
    [HttpDelete("delete-role-permission/{rolePermissionId:int}")]
    public async Task<IActionResult> DeleteRolePermission(int rolePermissionId, CancellationToken cancellationToken)
    {
        var result = await roleService.DeleteRolePermissionAsync(rolePermissionId, cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = result
        });
    }

}