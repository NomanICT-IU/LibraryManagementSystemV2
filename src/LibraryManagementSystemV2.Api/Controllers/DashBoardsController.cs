namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DashBoardsController(IDashboardInformationService dashboardInformationService) : ControllerBase
{
    [HttpGet("get-dashboard-information")]
    public async Task<IActionResult> GetDashBoardInformation(CancellationToken cancellationToken)
    {
        var result = await dashboardInformationService.GetDashboardInformationAsync(cancellationToken);
        return Ok(new ApiResponse<DashBoardDto> { Data = result });

    }
}
