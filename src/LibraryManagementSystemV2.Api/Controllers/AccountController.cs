namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IAuthService authService) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto loginRequestDto, CancellationToken cancellationToken)
    {
        var result = await authService.LoginAsync(loginRequestDto, cancellationToken);
        return Ok(new ApiResponse<LoginResult> { Data = result });
    }
}
