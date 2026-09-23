using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystemV2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PermissionsController(IPermissionService permissionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPermission(int roleId, CancellationToken cancellationToken)
        {
            var result = await permissionService.GetAllPermissionsAsync(roleId, cancellationToken);

            return Ok(new ApiResponse<IEnumerable<PermissionDto>>
            {
                Data = result
            });
        }
    }
}
