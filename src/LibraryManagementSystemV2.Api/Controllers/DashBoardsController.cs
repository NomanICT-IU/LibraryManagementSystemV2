namespace LibraryManagementSystemV2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DashBoardsController(IDashboardInformationService dashboardInformationService) : ControllerBase
{
    [HttpGet("get-dashboard-information")]
    public async Task<IActionResult> GetDashBoardInformation(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var result = await dashboardInformationService.GetDashboardInformationAsync(pageNumber, pageSize, cancellationToken);
        return Ok(new ApiResponse<DashBoardDto> { Data = result });
    }
}
