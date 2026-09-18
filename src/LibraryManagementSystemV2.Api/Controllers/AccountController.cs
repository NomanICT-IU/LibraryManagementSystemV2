namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IAuthService authService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> LogingAsync([FromQuery] LoginRequestDto loginRequestDto, CancellationToken cancellationToken)
    {

        var result = await authService.LoginAsync(loginRequestDto, cancellationToken);
        return Ok(new ApiResponse<LoginResponseDto> { Data = result });
    }
}
