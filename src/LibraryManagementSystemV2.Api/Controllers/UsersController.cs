namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser([FromBody] UserDto userDto, CancellationToken cancellationToken)
    {
        var result = await userService.CreateUserAsync(userDto, cancellationToken);

        return Ok(new ApiResponse<bool> { Data = result });

    }

    [HttpPut("update-user")]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto, CancellationToken cancellationToken)
    {
        var result = await userService.UpdateUserAsync(userDto, cancellationToken);
        return Ok(new ApiResponse<bool> { Data = result });
    }

    [HttpGet("get-user-by-id/{userId:int}")]
    public async Task<IActionResult> GetUserById(int userId, CancellationToken cancellationToken)
    {
        var result = await userService.GetUserByIdAsync(userId, cancellationToken);
        return Ok(new
        { Data = result });
    }

    [HttpDelete("delete-user/{userId:int}")]
    public async Task<IActionResult> DeleteUser(int userId, CancellationToken cancellationToken)
    {
        var result = await userService.DeleteUserAsync(userId, cancellationToken);
        return Ok(new
        { Data = result });
    }
}