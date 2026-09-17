namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController(IRoleService roleService) : ControllerBase
{
    // CREATE
    [HttpPost("create-role")]
    public async Task<IActionResult> CreateRole([FromBody] RoleDto roleDto, CancellationToken cancellationToken)
    {
        var result = await roleService.CreateRoleAsync(
            roleDto,
            cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = result
        });
    }


    // UPDATE
    [HttpPut("update-role")]
    public async Task<IActionResult> UpdateRole([FromBody] RoleDto roleDto, CancellationToken cancellationToken)
    {
        var result = await roleService.UpdateRoleAsync(
            roleDto,
            cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = result
        });
    }


    // GET BY ID
    [HttpGet("get-role-by-id/{roleId:int}")]
    public async Task<IActionResult> GetRoleById(int roleId, CancellationToken cancellationToken)
    {
        var result = await roleService.GetRoleByIdAsync(
            roleId,
            cancellationToken);

        return Ok(new ApiResponse<RoleDto>
        {
            Data = result
        });
    }


    // DELETE
    [HttpDelete("delete-role/{roleId:int}")]
    public async Task<IActionResult> DeleteRole(int roleId, CancellationToken cancellationToken)
    {
        var result = await roleService.DeleteRoleAsync(
            roleId,
            cancellationToken);

        return Ok(new ApiResponse<bool>
        {
            Data = result
        });
    }
}