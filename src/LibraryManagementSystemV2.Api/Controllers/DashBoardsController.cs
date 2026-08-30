namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DashBoardsController(IDashboardInformationService dashboardInformationService) : ControllerBase
{
    [HttpGet("get-dashboard-information/{recordLimit:int}")]
    public async Task<IActionResult> GetDashBoardInformation(int recordLimit, CancellationToken cancellationToken)
    {
        var result = await dashboardInformationService.GetDashboardInformationAsync(recordLimit, cancellationToken);
        return Ok(new ApiResponse<DashBoardDto>(
            result,
            "Dashboard data retrieved successfully."
            ));

    }
}
